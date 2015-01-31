namespace TP1___Refresh
{
    partial class Stage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListB_Entreprises = new System.Windows.Forms.ListBox();
            this.TB_NumStage = new System.Windows.Forms.TextBox();
            this.TB_TypeStage = new System.Windows.Forms.TextBox();
            this.BTN_Precedent = new System.Windows.Forms.Button();
            this.BTN_Suivant = new System.Windows.Forms.Button();
            this.LB_Numstage = new System.Windows.Forms.Label();
            this.LB_Description = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RTB_Description = new System.Windows.Forms.RichTextBox();
            this.BTN_Ajouter = new System.Windows.Forms.Button();
            this.BTN_Sauvegarder = new System.Windows.Forms.Button();
            this.BTN_Effacer = new System.Windows.Forms.Button();
            this.LB_Entreprises = new System.Windows.Forms.Label();
            this.LB_NomEntreprise = new System.Windows.Forms.Label();
            this.CB_NomEntreprise = new System.Windows.Forms.ComboBox();
            this.BTN_Vider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListB_Entreprises
            // 
            this.ListB_Entreprises.FormattingEnabled = true;
            this.ListB_Entreprises.ItemHeight = 20;
            this.ListB_Entreprises.Location = new System.Drawing.Point(519, 57);
            this.ListB_Entreprises.Name = "ListB_Entreprises";
            this.ListB_Entreprises.Size = new System.Drawing.Size(215, 204);
            this.ListB_Entreprises.TabIndex = 0;
            this.ListB_Entreprises.SelectedIndexChanged += new System.EventHandler(this.ListB_Entreprises_SelectedIndexChanged);
            // 
            // TB_NumStage
            // 
            this.TB_NumStage.Enabled = false;
            this.TB_NumStage.Location = new System.Drawing.Point(175, 21);
            this.TB_NumStage.Name = "TB_NumStage";
            this.TB_NumStage.Size = new System.Drawing.Size(175, 26);
            this.TB_NumStage.TabIndex = 1;
            // 
            // TB_TypeStage
            // 
            this.TB_TypeStage.Location = new System.Drawing.Point(175, 173);
            this.TB_TypeStage.Name = "TB_TypeStage";
            this.TB_TypeStage.Size = new System.Drawing.Size(175, 26);
            this.TB_TypeStage.TabIndex = 1;
            // 
            // BTN_Precedent
            // 
            this.BTN_Precedent.Location = new System.Drawing.Point(57, 289);
            this.BTN_Precedent.Name = "BTN_Precedent";
            this.BTN_Precedent.Size = new System.Drawing.Size(112, 34);
            this.BTN_Precedent.TabIndex = 2;
            this.BTN_Precedent.Text = "Précédent";
            this.BTN_Precedent.UseVisualStyleBackColor = true;
            this.BTN_Precedent.Click += new System.EventHandler(this.BTN_Precedent_Click);
            // 
            // BTN_Suivant
            // 
            this.BTN_Suivant.Location = new System.Drawing.Point(238, 289);
            this.BTN_Suivant.Name = "BTN_Suivant";
            this.BTN_Suivant.Size = new System.Drawing.Size(112, 34);
            this.BTN_Suivant.TabIndex = 2;
            this.BTN_Suivant.Text = "Suivant";
            this.BTN_Suivant.UseVisualStyleBackColor = true;
            this.BTN_Suivant.Click += new System.EventHandler(this.BTN_Suivant_Click);
            // 
            // LB_Numstage
            // 
            this.LB_Numstage.AutoSize = true;
            this.LB_Numstage.Location = new System.Drawing.Point(38, 21);
            this.LB_Numstage.Name = "LB_Numstage";
            this.LB_Numstage.Size = new System.Drawing.Size(131, 20);
            this.LB_Numstage.TabIndex = 3;
            this.LB_Numstage.Text = "Numéro de stage";
            // 
            // LB_Description
            // 
            this.LB_Description.AutoSize = true;
            this.LB_Description.Location = new System.Drawing.Point(38, 70);
            this.LB_Description.Name = "LB_Description";
            this.LB_Description.Size = new System.Drawing.Size(89, 20);
            this.LB_Description.TabIndex = 3;
            this.LB_Description.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type de stage";
            // 
            // RTB_Description
            // 
            this.RTB_Description.Location = new System.Drawing.Point(175, 67);
            this.RTB_Description.Name = "RTB_Description";
            this.RTB_Description.Size = new System.Drawing.Size(175, 82);
            this.RTB_Description.TabIndex = 4;
            this.RTB_Description.Text = "";
            // 
            // BTN_Ajouter
            // 
            this.BTN_Ajouter.Location = new System.Drawing.Point(385, 40);
            this.BTN_Ajouter.Name = "BTN_Ajouter";
            this.BTN_Ajouter.Size = new System.Drawing.Size(112, 34);
            this.BTN_Ajouter.TabIndex = 2;
            this.BTN_Ajouter.Text = "Ajouter stage";
            this.BTN_Ajouter.UseVisualStyleBackColor = true;
            this.BTN_Ajouter.Click += new System.EventHandler(this.BTN_Ajouter_Click);
            // 
            // BTN_Sauvegarder
            // 
            this.BTN_Sauvegarder.Location = new System.Drawing.Point(385, 93);
            this.BTN_Sauvegarder.Name = "BTN_Sauvegarder";
            this.BTN_Sauvegarder.Size = new System.Drawing.Size(112, 34);
            this.BTN_Sauvegarder.TabIndex = 2;
            this.BTN_Sauvegarder.Text = "Sauvegarder";
            this.BTN_Sauvegarder.UseVisualStyleBackColor = true;
            this.BTN_Sauvegarder.Click += new System.EventHandler(this.BTN_Sauvegarder_Click);
            // 
            // BTN_Effacer
            // 
            this.BTN_Effacer.Location = new System.Drawing.Point(385, 147);
            this.BTN_Effacer.Name = "BTN_Effacer";
            this.BTN_Effacer.Size = new System.Drawing.Size(112, 34);
            this.BTN_Effacer.TabIndex = 2;
            this.BTN_Effacer.Text = "Effacer";
            this.BTN_Effacer.UseVisualStyleBackColor = true;
            this.BTN_Effacer.Click += new System.EventHandler(this.BTN_Effacer_Click);
            // 
            // LB_Entreprises
            // 
            this.LB_Entreprises.AutoSize = true;
            this.LB_Entreprises.Location = new System.Drawing.Point(519, 21);
            this.LB_Entreprises.Name = "LB_Entreprises";
            this.LB_Entreprises.Size = new System.Drawing.Size(215, 20);
            this.LB_Entreprises.TabIndex = 5;
            this.LB_Entreprises.Text = "Entreprises offrants un stage";
            // 
            // LB_NomEntreprise
            // 
            this.LB_NomEntreprise.AutoSize = true;
            this.LB_NomEntreprise.Location = new System.Drawing.Point(38, 223);
            this.LB_NomEntreprise.Name = "LB_NomEntreprise";
            this.LB_NomEntreprise.Size = new System.Drawing.Size(117, 20);
            this.LB_NomEntreprise.TabIndex = 3;
            this.LB_NomEntreprise.Text = "Nom entreprise";
            // 
            // CB_NomEntreprise
            // 
            this.CB_NomEntreprise.Cursor = System.Windows.Forms.Cursors.Default;
            this.CB_NomEntreprise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_NomEntreprise.FormattingEnabled = true;
            this.CB_NomEntreprise.Location = new System.Drawing.Point(175, 220);
            this.CB_NomEntreprise.Name = "CB_NomEntreprise";
            this.CB_NomEntreprise.Size = new System.Drawing.Size(175, 28);
            this.CB_NomEntreprise.TabIndex = 6;
            // 
            // BTN_Vider
            // 
            this.BTN_Vider.Location = new System.Drawing.Point(385, 200);
            this.BTN_Vider.Name = "BTN_Vider";
            this.BTN_Vider.Size = new System.Drawing.Size(112, 34);
            this.BTN_Vider.TabIndex = 2;
            this.BTN_Vider.Text = "Vider";
            this.BTN_Vider.UseVisualStyleBackColor = true;
            this.BTN_Vider.Click += new System.EventHandler(this.BTN_Vider_Click);
            // 
            // Stage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 353);
            this.Controls.Add(this.CB_NomEntreprise);
            this.Controls.Add(this.LB_Entreprises);
            this.Controls.Add(this.RTB_Description);
            this.Controls.Add(this.LB_NomEntreprise);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LB_Description);
            this.Controls.Add(this.LB_Numstage);
            this.Controls.Add(this.BTN_Vider);
            this.Controls.Add(this.BTN_Effacer);
            this.Controls.Add(this.BTN_Sauvegarder);
            this.Controls.Add(this.BTN_Ajouter);
            this.Controls.Add(this.BTN_Suivant);
            this.Controls.Add(this.BTN_Precedent);
            this.Controls.Add(this.TB_TypeStage);
            this.Controls.Add(this.TB_NumStage);
            this.Controls.Add(this.ListB_Entreprises);
            this.Name = "Stage";
            this.Text = "Stage";
            this.Load += new System.EventHandler(this.Stage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListB_Entreprises;
        private System.Windows.Forms.TextBox TB_NumStage;
        private System.Windows.Forms.TextBox TB_TypeStage;
        private System.Windows.Forms.Button BTN_Precedent;
        private System.Windows.Forms.Button BTN_Suivant;
        private System.Windows.Forms.Label LB_Numstage;
        private System.Windows.Forms.Label LB_Description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox RTB_Description;
        private System.Windows.Forms.Button BTN_Ajouter;
        private System.Windows.Forms.Button BTN_Sauvegarder;
        private System.Windows.Forms.Button BTN_Effacer;
        private System.Windows.Forms.Label LB_Entreprises;
        private System.Windows.Forms.Label LB_NomEntreprise;
        private System.Windows.Forms.ComboBox CB_NomEntreprise;
        private System.Windows.Forms.Button BTN_Vider;
    }
}