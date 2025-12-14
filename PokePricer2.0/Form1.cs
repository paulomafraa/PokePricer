using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json;

namespace PokePricer2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtLogin.Text = "";
            txtSenha.Text = "";
            btnPrecificar.Click += btnPrecificar_Click;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cartas.json");
            string precosPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "precos_pokemon.json");

            var options = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();

            var cartasExtraidas = new List<CartaPokemon>();

            using (var driver = new ChromeDriver(service, options))
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                driver.Navigate().GoToUrl("https://www.tcgcollector.com/account/sign-in");

                var inputUser = wait.Until(d => d.FindElement(By.CssSelector("input#sign-in-email-address")));
                inputUser.Clear();
                inputUser.SendKeys(txtLogin.Text);

                var inputPass = driver.FindElement(By.CssSelector("input#sign-in-password"));
                inputPass.Clear();
                inputPass.SendKeys(txtSenha.Text);

                var btnSubmit = driver.FindElement(By.XPath("//button[@type='submit']"));
                btnSubmit.Click();

                wait.Until(d => d.Url.Contains("dashboard"));

                string baseUrl = "https://www.tcgcollector.com/cards?cardSource=inCardCollection&releaseDateOrder=newToOld&displayAs=images&cardsPerPage=120";
                driver.Navigate().GoToUrl(baseUrl);
                System.Threading.Thread.Sleep(500);

                var pageItems = driver.FindElements(By.CssSelector("li.pagination-item"));
                var pageNumbers = new List<int>();
                foreach (var item in pageItems)
                {
                    try
                    {
                        var link = item.FindElement(By.CssSelector("a.pagination-link"));
                        int num = int.Parse(link.Text.Trim());
                        pageNumbers.Add(num);
                    }
                    catch { }
                }
                int totalPages = pageNumbers.Count > 0 ? Math.Max(1, pageNumbers[pageNumbers.Count - 1]) : 1;

                for (int pageNum = 1; pageNum <= totalPages; pageNum++)
                {
                    string url = pageNum > 1 ? $"{baseUrl}&page={pageNum}" : baseUrl;
                    driver.Navigate().GoToUrl(url);

                    wait.Until(d => d.FindElements(By.CssSelector("div.card-image-grid-item")).Count > 0);

                    var cards = driver.FindElements(By.CssSelector("div.card-image-grid-item"));
                    foreach (var card in cards)
                    {
                        try
                        {
                            var linkElement = card.FindElement(By.CssSelector("a.card-image-grid-item-link"));
                            string title = linkElement.GetAttribute("title");
                            string cardId = card.GetAttribute("data-card-id");
                            string cardUrl = linkElement.GetAttribute("href");

                            string name, set;
                            if (title.Contains("(") && title.Contains(")"))
                            {
                                name = title.Split('(')[0].Trim();
                                string conteudoParenteses = title.Split('(')[1].Split(')')[0].Trim();
                                var partes = conteudoParenteses.Split(' ');
                                string numero = partes[partes.Length - 1];

                                string setFormatado = numero;
                                if (numero.Contains("/"))
                                {
                                    var splitSet = numero.Split('/');
                                    if (splitSet.Length == 2)
                                        setFormatado = $"{splitSet[0].Trim()}/{splitSet[1].Trim()}";
                                }
                                set = setFormatado;
                            }
                            else
                            {
                                name = title.Trim();
                                set = "Desconhecido";
                            }

                            cartasExtraidas.Add(new CartaPokemon
                            {
                                Nome = name,
                                Set = set,
                                CardId = cardId,
                                Url = cardUrl
                            });
                        }
                        catch { }
                    }
                }
            }

            List<CartaPokemon> cartasSalvas = new List<CartaPokemon>();
            if (File.Exists(jsonPath))
            {
                string jsonExistente = File.ReadAllText(jsonPath);
                cartasSalvas = JsonConvert.DeserializeObject<List<CartaPokemon>>(jsonExistente) ?? new List<CartaPokemon>();
            }

            foreach (var carta in cartasExtraidas)
            {
                if (!cartasSalvas.Exists(c => c.CardId == carta.CardId))
                    cartasSalvas.Add(carta);
            }
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(cartasSalvas, Formatting.Indented));

            if (!executarPrice.Checked)
            {
                MessageBox.Show("Cartas exportadas para cartas.json com sucesso!");
            }

            if (executarPrice.Checked)
            {
                ConverterPrecos();
            }
        }

        private void ConverterPrecos()
        {
            string cartasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cartas.json");
            string precosPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "precos_pokemon.json");

            if (!File.Exists(cartasPath))
            {
                MessageBox.Show("Arquivo cartas.json não encontrado!");
                return;
            }

            var cartas = JsonConvert.DeserializeObject<List<CartaPokemon>>(File.ReadAllText(cartasPath));
            var precos = new List<CartaPreco>();

            var options = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();

            using (var driver = new ChromeDriver(service, options))
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

                foreach (var carta in cartas)
                {
                    try
                    {
                        string numeroCarta = carta.Set;

                        string searchQuery = Uri.EscapeDataString($"{carta.Nome} ({numeroCarta})");
                        string url = $"https://www.ligapokemon.com.br/?view=cards/search&card={searchQuery}";

                        driver.Navigate().GoToUrl(url);
                        wait.Until(d => d.FindElements(By.CssSelector("div.card-image-grid-item")).Count > 0);

                        var cardBoxes = driver.FindElements(By.CssSelector("#mtg-cards .box.p25"));

                        bool clicou = false;
                        foreach (var box in cardBoxes)
                        {
                            var nomeEl = box.FindElement(By.CssSelector(".mtg-name a"));
                            var nome = nomeEl.Text.Trim();

                            var edicaoEl = box.FindElement(By.CssSelector(".edition-name"));
                            var edicao = edicaoEl.Text.Trim();

                            if (nome.Equals(carta.Nome, StringComparison.OrdinalIgnoreCase) && !edicao.Contains("JP"))
                            {
                                nomeEl.Click();
                                clicou = true;
                                break;
                            }
                        }

                        if (!clicou && cardBoxes.Count > 1)
                        {
                            MessageBox.Show($"{carta.Nome} PT/EN não encontrado nos resultados!");
                        }

                        var priceElements = driver.FindElements(By.CssSelector("div.new-price.price-with-image, .new-price, .price"));
                        decimal menorPreco = -1;
                        string condicaoMenorPreco = null;
                        foreach (var el in priceElements)
                        {
                            string priceText = el.Text.Replace("R$", "").Replace(".", "").Replace(",", ".").Trim();
                            string condicao = null;
                            try
                            {
                                var ancestor = el.FindElement(By.XPath("ancestor::div[contains(@class,'quantity-and-price')]"));
                                var qualityDiv = ancestor.FindElement(By.CssSelector("div.quality"));
                                condicao = qualityDiv.GetAttribute("title")?.Trim() ?? qualityDiv.Text.Trim();
                            }
                            catch
                            {
                                condicao = "Desconhecida";
                            }

                            if (decimal.TryParse(priceText, out decimal preco))
                            {
                                if (menorPreco == -1 || preco < menorPreco)
                                {
                                    menorPreco = preco;
                                    condicaoMenorPreco = condicao;
                                }
                            }
                        }

                        precos.Add(new CartaPreco
                        {
                            Nome = carta.Nome,
                            Set = carta.Set,
                            CardId = carta.CardId,
                            Url = carta.Url,
                            Preco = menorPreco > 0 ? menorPreco : (decimal?)null,
                            Condicao = condicaoMenorPreco
                        });
                    }
                    catch (Exception ex)
                    {
                        precos.Add(new CartaPreco
                        {
                            Nome = carta.Nome,
                            Set = carta.Set,
                            CardId = carta.CardId,
                            Url = carta.Url,
                            Preco = null
                        });
                    }
                }
            }

            File.WriteAllText(precosPath, JsonConvert.SerializeObject(precos, Formatting.Indented));
            MessageBox.Show("Preços exportados para precos_pokemon.json com sucesso!");
        }

        private void btnPrecificar_Click(object sender, EventArgs e)
        {
            ConverterPrecos();
        }
    }

    public class CartaPokemon
    {
        public string Nome { get; set; }
        public string Set { get; set; }
        public string CardId { get; set; }
        public string Url { get; set; }
    }

    public class CartaPreco
    {
        public string Nome { get; set; }
        public string Set { get; set; }
        public string CardId { get; set; }
        public string Url { get; set; }
        public decimal? Preco { get; set; }
        public string Condicao { get; set; }
    }
}