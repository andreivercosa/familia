using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;

namespace View.Pages
{

    public partial class MaeCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando o cadastro";
        }
        protected void btnCadastrarMae(object sender, EventArgs e)
        {
            try
            {
                Mae mae = new Mae();
                MaeDal maeDal = new MaeDal();
                mae.Nome = nome.Text;
                maeDal.Salvar(mae);

                nome.Text = "";


                string msg = "Mae " + mae.Nome + "-" + " foi cadastrado com Sucesso";
                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;

                //Thread.Sleep(5000);

                // Response.Redirect("http://127.0.0.1:8080/Pages/MaeCadastro.aspx");
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