using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;

namespace View.Pages
{

    public partial class PaiLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
           
        }
        public void btnPesquisarPai(object sender, EventArgs e)
        {
            string nomePai = nome.Text;
            PaiDal especialidadeDal = new PaiDal();

            gridListaPai.DataSource = especialidadeDal.PesquisarPorNome(nomePai);
            gridListaPai.DataBind();

        }
    }
}
