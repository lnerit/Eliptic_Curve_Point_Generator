using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtXValue_TextChanged(object sender, EventArgs e)
        {
            try { 
            if (txtModpValue.Text == "")
            {
                Mod23.Modp.p = 23;
                //txtModpValue.Text = "23";
            }
            else
            {
                    if (Modp.IsPrime(int.Parse(txtModpValue.Text)))
                    {
                        Mod23.Modp.p = int.Parse(txtModpValue.Text);
                    }
                    else
                    {
                        txtModpValue.Text = "23";
                    }
            }

            if (txtConstantA.Text!="" && TxtConstantB.Text != "" && txtXValue.Text!="")
            {
               // int x = int.Parse(txtXValue.Text);
                int a = int.Parse(txtConstantA.Text);
                int b = int.Parse(TxtConstantB.Text);
                    string[] array = txtXValue.Text.Split(',');
                    textBox1.Text = "";
                    if (array.Length > 0)
                    {
                        foreach (string s in array)
                        {
                            if (s != "")
                            {
                                textBox1.Text += Modp.GenerateEllipticPoint(int.Parse(s), a, b);
                            }
                        }
                    }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtConstantA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtModpValue.Text == "")
                {
                    Mod23.Modp.p = 23;
                   // txtModpValue.Text = "23";
                }
                else
                {
                    if (Modp.IsPrime(int.Parse(txtModpValue.Text)))
                    {
                      
                            Mod23.Modp.p = int.Parse(txtModpValue.Text);              
                    }
                }

                if (txtConstantA.Text != "" && TxtConstantB.Text != "" && txtXValue.Text != "")
                {
                    txtXValue_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtConstantB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtModpValue.Text == "")
                {
                    Mod23.Modp.p = 23;
                    //txtModpValue.Text = "23";
                }
                else
                {
                    if (Modp.IsPrime(int.Parse(txtModpValue.Text)))
                    {
                        Mod23.Modp.p = int.Parse(txtModpValue.Text);
                    }
                    /*else
                    {
                        txtModpValue.Text = "23";
                    }*/
                }

                if (txtConstantA.Text != "" && TxtConstantB.Text != "" && txtXValue.Text != "")
                {
                    txtXValue_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtModpValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtModpValue.Text == "")
                {
                    //Mod23.Modp.p = 23;
                   // return;

                }
                else
                {
                    if (Modp.IsPrime(int.Parse(txtModpValue.Text)))
                    {
                        Mod23.Modp.p = int.Parse(txtModpValue.Text);
                    }

                }

                if (txtConstantA.Text != "" && TxtConstantB.Text != "" && txtXValue.Text != "")
                {
                    txtXValue_TextChanged(sender, e);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtModpValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtXValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar!=',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtConstantA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TxtConstantB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
