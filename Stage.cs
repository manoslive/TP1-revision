using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace TP1___Refresh
{
    public partial class Stage : Form
    {
        DataSet stageDS = new DataSet();
        OracleConnection oracon = new OracleConnection();
        private String nomEntreprise { get; set; }

        private string Dsource = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
"(HOST=205.237.244.251)(PORT=1521)))" + "(CONNECT_DATA=(SERVICE_NAME=ORCL.clg.qc.ca)))";
        public Stage()
        {
            InitializeComponent();
        }
        public bool Connect()
        {
            bool resultat = false;
            try
            {
                string chaineConnection = "Data Source = " + Dsource + ";User Id =cooperch;Password=ORACLE1";
                oracon.ConnectionString = chaineConnection;
                oracon.Open();
                if (oracon.State == ConnectionState.Open)
                {
                    if (MessageBox.Show("Vous êtes maintenant connecté!" + "\n" + "Bienvenue dans un monde rempli d'intrigues!", "État de connection à la BD") == DialogResult.OK)
                    {
                        resultat = true;
                    }
                }
                else
                {
                    MessageBox.Show("ERREUUUUR", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resultat = false;
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return resultat;
        }
        private void Stage_Load(object sender, EventArgs e)
        {
            Connect();
            RemplirFormulaire();
        }
        private void RemplirFormulaire()
        {
            OracleCommand oraSelect = oracon.CreateCommand();
            oraSelect.CommandText = "Select * From StagesEntreprises " +
                                    "where NomEnt=:NomEnt";
            OracleParameter OraParamNomEnt = new OracleParameter(":NomEnt", OracleDbType.Varchar2);
            OraParamNomEnt.Value = 102;
            oraSelect.Parameters.Add(OraParamNomEnt);
            using (OracleDataAdapter oraAdapter = new OracleDataAdapter(oraSelect))
            {
                if (stageDS.Tables.Contains("STAGES"))
                {
                    stageDS.Tables["STAGES"].Clear();
                }
                oraAdapter.Fill(stageDS, "STAGES");
                oraAdapter.Dispose();
            }
            UpdateLinkTB();
        }
        private void UpdateLinkTB()
        {
            UnbindTB();
            TB_NumStage.DataBindings.Add("Text", stageDS, "STAGES.NumStg");
            RTB_Description.DataBindings.Add("Text", stageDS, "STAGES.Description");
            TB_TypeStage.DataBindings.Add("Text", stageDS, "STAGES.TypeStg");
        }
        private void UnbindTB()
        {
            TB_NumStage.DataBindings.Clear();
            TB_NumStage.Clear();
            RTB_Description.DataBindings.Clear();
            RTB_Description.Clear();
            TB_TypeStage.DataBindings.Clear();
            TB_TypeStage.Clear();
        }
        /*  private void Ajouter()
          {
              string sql = "insert into FicheJoueur" +
                           "(NumeroMatch, NumeroJoueur, NombreButs, NombrePasses, TempsPunition) " +
                           "Values(:NumeroMatch,:NumeroJoueur,:NombreButs,:NombrePasses,:TempsPunition)";
              try
              {
                  OracleCommand oraAjout = new OracleCommand(sql, oracon);

                  OracleParameter OraParaNumeroMatch = new OracleParameter(":NumeroMatch", OracleDbType.Int32);
                  OracleParameter OraParamNumeroJoueur = new OracleParameter(":NumeroJoueur", OracleDbType.Varchar2, 40);


                  OraParaNumeroMatch.Value = aJ.numMatch;


                  oraAjout.Parameters.Add(OraParaNumeroMatch);

                  oraAjout.ExecuteNonQuery();
                  RemplirFormulaire();
              }
              catch (OracleException ex) // Erreur "child exists"
              {
                  if (ex.Number == 2292)
                      MessageBox.Show("Le joueur ne doit pas avoir de statistique dans les matchs", "Erreur 2292", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  else
                      MessageBox.Show(ex.Message.ToString());
              }
          }
          private void Modifier()
          {
              Form_Ajouter_Stats ajs = new Form_Ajouter_Stats(oracon, connection);
              ajs.isModif = false;
              ajs.callBackForm = this;
              ajs.Text = "Modification des Statistiques";
              ajs.numMatch = TB_NumMatch.Text;
              ajs.numJoueur = TB_NumJoueur.Text;
              ajs.nbButs = TB_NbButs.Text;
              ajs.nbPasses = TB_NbPasses.Text;
              ajs.tempsPunition = TB_TempsPunition.Text;
              ajs.Location = this.Location;
              this.Hide();

              if (ajs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
              {
                  string sql = "update FicheJoueur set NumeroMatch=:NumeroMatch, NumeroJoueur=:NumeroJoueur, NombreButs=:NombreButs, NombrePasses=:NombrePasses, TempsPunition=:TempsPunition " +
                                  "where numerojoueur=:numerojoueur";
                  try
                  {

                      OracleCommand oraAjout = new OracleCommand(sql, oracon);

                      OracleParameter OraParaNumeroMatch = new OracleParameter(":NumeroMatch", OracleDbType.Int32);
                      OracleParameter OraParamNumeroJoueur = new OracleParameter(":NumeroJoueur", OracleDbType.Int32);
                      OracleParameter OraParamNombreButs = new OracleParameter(":NombreButs", OracleDbType.Int32);
                      OracleParameter OraParaNombrePasses = new OracleParameter(":NombrePasses", OracleDbType.Int32);
                      OracleParameter OraParaTempsPunition = new OracleParameter(":TempsPunition", OracleDbType.Int32);

                      OraParaNumeroMatch.Value = ajs.numMatch;
                      OraParamNumeroJoueur.Value = ajs.numJoueur;
                      OraParamNombreButs.Value = ajs.nbButs;
                      OraParaNombrePasses.Value = ajs.nbPasses;
                      OraParaTempsPunition.Value = ajs.tempsPunition;

                      oraAjout.Parameters.Add(OraParaNumeroMatch);
                      oraAjout.Parameters.Add(OraParamNumeroJoueur);
                      oraAjout.Parameters.Add(OraParamNombreButs);
                      oraAjout.Parameters.Add(OraParaNombrePasses);
                      oraAjout.Parameters.Add(OraParaTempsPunition);

                      oraAjout.ExecuteNonQuery();

                      RemplirFormulaire();
                  }
                  catch (OracleException ex)
                  {
                      MessageBox.Show(ex.Message.ToString());
                  }

              }
          }
          private void Supprimer()
          {
              if (MessageBox.Show("Voulez-vous vraiment effacer cette entrée ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
              {
                  try
                  {
                      OracleParameter paramNomEquipe = new OracleParameter(":numjoueur", OracleDbType.Int32);
                      paramNomEquipe.Value = TB_NumJoueur.Text;
                      string sql = "Delete from joueur Where numerojoueur =:numjoueur";
                      OracleCommand oraDelete = new OracleCommand(sql, oracon);
                      oraDelete.Parameters.Add(paramNomEquipe);
                      oraDelete.ExecuteNonQuery();
                      RemplirFormulaire();
                  }
                  catch (OracleException ex)
                  {
                      if (ex.Number == 2292) // Erreur "child exists"
                          MessageBox.Show("Vous ne pouvez pas effacer des joueurs avec des matchs", "Erreur 2292", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      else
                          MessageBox.Show(ex.Message.ToString());
                  }
              }
          }
         */

        private void BTN_Precedent_Click(object sender, EventArgs e)
        {
            this.BindingContext[stageDS, "STAGES"].Position--;
        }

        private void BTN_Suivant_Click(object sender, EventArgs e)
        {
            this.BindingContext[stageDS, "STAGES"].Position++;
        }

        private void LB_Entreprises_SelectedIndexChanged(object sender, EventArgs e)
        {
            nomEntreprise = LB_Entreprises.SelectedItem.ToString();
        }
    }
}
