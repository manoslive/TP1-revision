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

        private void Stage_Load(object sender, EventArgs e)
        {
            Connect();
            FillListBox();
            FillComboBox();
            // Selection de base du listbox
            ListB_Entreprises.SelectedIndex = 0;
            RemplirFormulaire();
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
        private void RemplirFormulaire()
        {
            OracleCommand oraSelect = oracon.CreateCommand();
            oraSelect.CommandText = "Select * From StagesEntreprises " +
                                    "where NomEnt=:NomEnt";
            OracleParameter OraParamNomEnt = new OracleParameter(":NomEnt", OracleDbType.Varchar2);
            OraParamNomEnt.Value = nomEntreprise;
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
            CB_NumEntreprise.DataBindings.Add("Text", stageDS, "STAGES.NumEnt");
        }
        private void UnbindTB()
        {
            TB_NumStage.DataBindings.Clear();
            TB_NumStage.Clear();
            RTB_Description.DataBindings.Clear();
            RTB_Description.Clear();
            TB_TypeStage.DataBindings.Clear();
            TB_TypeStage.Clear();
            CB_NumEntreprise.DataBindings.Clear();
            //CB_NomEntreprise.Items.Clear();
        }
        private void Ajouter()
        {
            string sql = "insert into Stages (numstg, description, nument, typestg) " +
                         "Values(NUMSTG_seq.nextval, :Description, :NumEnt, :Typestg)";
            try
            {
                OracleCommand oraAjout = new OracleCommand(sql, oracon);

                OracleParameter OraParaNomEnt = new OracleParameter(":NumEnt", OracleDbType.Varchar2, 5);
                OracleParameter OraParaDesc = new OracleParameter(":Description", OracleDbType.Varchar2, 40);
                OracleParameter OraParamTypestg = new OracleParameter(":Typestg", OracleDbType.Char, 3);

                OraParaNomEnt.Value = CB_NumEntreprise.Text;
                OraParaDesc.Value = RTB_Description.Text;
                OraParamTypestg.Value = TB_TypeStage.Text;

                oraAjout.Parameters.Add(OraParaDesc);
                oraAjout.Parameters.Add(OraParaNomEnt);
                oraAjout.Parameters.Add(OraParamTypestg);

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
            string sql = "update STAGES set Description=:Description nument=:nument, typestg=:TypeStg " +
                            "where numstg=:numstg";
            try
            {

                OracleCommand oraAjout = new OracleCommand(sql, oracon);
                
                OracleParameter OraParaDescription = new OracleParameter(":Description", OracleDbType.Varchar2, 50);
                OracleParameter OraParamNumEnt = new OracleParameter(":Nument", OracleDbType.Varchar2, 5);
                OracleParameter OraParamTypeStg = new OracleParameter(":TypeStg", OracleDbType.Char, 3);

                OraParaDescription.Value = RTB_Description.Text;
                OraParamTypeStg.Value = TB_TypeStage.Text;


                oraAjout.Parameters.Add(OraParaDescription);
                oraAjout.Parameters.Add(OraParamTypeStg);

                oraAjout.ExecuteNonQuery();

                RemplirFormulaire();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BTN_Ajouter_Click(object sender, EventArgs e)
        {
            Ajouter();
        }

        private void BTN_Sauvegarder_Click(object sender, EventArgs e)
        {
            Modifier();
        }

        private void BTN_Effacer_Click(object sender, EventArgs e)
        {
            Supprimer();
        }
        private void Supprimer()
        {
            if (MessageBox.Show("Voulez-vous vraiment effacer cette entrée ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    OracleParameter paramNumStg = new OracleParameter(":NumStg", OracleDbType.Varchar2, 5);
                    paramNumStg.Value = TB_NumStage.Text;
                    string sql = "Delete from stages Where NumStg=:NumStg";
                    OracleCommand oraDelete = new OracleCommand(sql, oracon);
                    oraDelete.Parameters.Add(paramNumStg);
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

        private void FillListBox()
        {
            try
            {


                OracleCommand oraSelect = oracon.CreateCommand();
                oraSelect.CommandText = "Select NomEnt From Entreprises";
                using (OracleDataReader oraReader = oraSelect.ExecuteReader())
                {
                    while (oraReader.Read())
                    {
                        ListB_Entreprises.Items.Add(oraReader.GetString(0));
                    }
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FillComboBox()
        {
            try
            {


                OracleCommand oraSelect = oracon.CreateCommand();
                oraSelect.CommandText = "Select NumEnt From Entreprises";
                using (OracleDataReader oraReader = oraSelect.ExecuteReader())
                {
                    while (oraReader.Read())
                    {
                        CB_NumEntreprise.Items.Add(oraReader.GetString(0));
                    }
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BTN_Precedent_Click(object sender, EventArgs e)
        {
            this.BindingContext[stageDS, "STAGES"].Position--;
        }

        private void BTN_Suivant_Click(object sender, EventArgs e)
        {
            this.BindingContext[stageDS, "STAGES"].Position++;
        }

        private void ListB_Entreprises_SelectedIndexChanged(object sender, EventArgs e)
        {
            nomEntreprise = ListB_Entreprises.GetItemText(ListB_Entreprises.SelectedItem);
            CB_NumEntreprise.SelectedText = nomEntreprise;
            RemplirFormulaire();
        }

        private void BTN_Vider_Click(object sender, EventArgs e)
        {
            TB_NumStage.Clear();
            RTB_Description.Clear();
            TB_TypeStage.Clear();
            CB_NumEntreprise.SelectedIndex = -1;
        }
    }
}
