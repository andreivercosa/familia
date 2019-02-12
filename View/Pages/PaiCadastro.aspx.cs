using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;

namespace View.Pages
{

    public partial class PaiCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando o cadastro";
        }
        protected void btnCadastrarPai(object sender, EventArgs e)
        {
            try
            {
                Pai pai = new Pai();
                PaiDal paiDal = new PaiDal();
                pai.Nome = nome.Text;
                paiDal.Salvar(pai);

                nome.Text = "";
               

                string msg = "Pai " + pai.Nome + "-" + " foi cadastrado com Sucesso";
                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;

                //Thread.Sleep(5000);

                // Response.Redirect("http://127.0.0.1:8080/Pages/PaiCadastro.aspx");
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
            }
            finally
            {

            }
        }
    }

}