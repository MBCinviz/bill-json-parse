using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillJsonParse
{
    public partial class Form1 : Form
    {
        private Button selectButton;
        private OpenFileDialog openFileDialog1;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Select json files (*.json)|*.json",
                Title = "Open json file"
            };

            selectButton = new Button()
            {
                Size = new Size(100, 20),
                Location = new Point(15, 15),
                Text = "Select file"
            };
            selectButton.Click += new EventHandler(btnJsonParse_Click);
            Controls.Add(selectButton);
        }

        public class bill
        {
            public billLine billL { get; set; }
        }
        public class billLine
        {
            public string locale { get; set; }
            public string description { get; set; }

            public boundingPolyValues boundingPoly { get; set; }
        }

        public class boundingPolyValues
        {
            [JsonProperty("vertices")]
            public List<vertice> vertices { get; set; }
            public boundingPolyValues() { vertices = new List<vertice>(); }
        }

        public class vertice
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        private void btnJsonParse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        StreamReader reader = new StreamReader(str);
                        string text = reader.ReadToEnd();

                        List<billLine> billLines = Newtonsoft.Json.JsonConvert.DeserializeObject<List<billLine>>(text);
                        var sortedList = billLines.OrderBy(x => x.boundingPoly.vertices[0].y).ThenBy(x => x.boundingPoly.vertices[0].x).ToList();
                        StringBuilder stringBuilder = new StringBuilder("Line |\t Text");
                        int previousLine1 = -1;
                        int previousLine2 = -1;
                        int outputLine = 1;
                        foreach (var item in sortedList)
                        {
                            if (item.locale == "tr")
                            { continue; }
                            int y1 = item.boundingPoly.vertices[0].y;
                            int y2 = item.boundingPoly.vertices[3].y;
                            if (previousLine2>y1)
                            {
                                stringBuilder.Append(" ");
                            }
                            else
                            {
                                stringBuilder.Append("\r\n").Append(outputLine++).Append(" |\t");
                            }

                            stringBuilder.Append(item.description);
                            previousLine1 = y1;
                            previousLine2 = y2;

                        }
                        textJsonConvert.Text = stringBuilder.ToString();
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
