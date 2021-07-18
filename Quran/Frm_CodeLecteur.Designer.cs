namespace Quran
{
    partial class Frm_CodeLecteur
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
            this.ckPetit = new System.Windows.Forms.RadioButton();
            this.ckGrand = new System.Windows.Forms.RadioButton();
            this.treeVLecteur = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_nom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btAjout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ckPetit
            // 
            this.ckPetit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckPetit.AutoSize = true;
            this.ckPetit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPetit.Location = new System.Drawing.Point(133, 81);
            this.ckPetit.Name = "ckPetit";
            this.ckPetit.Size = new System.Drawing.Size(119, 28);
            this.ckPetit.TabIndex = 22;
            this.ckPetit.TabStop = true;
            this.ckPetit.Text = "الجمع الصغرى";
            this.ckPetit.UseVisualStyleBackColor = true;
            this.ckPetit.CheckedChanged += new System.EventHandler(this.ckPetit_CheckedChanged);
            // 
            // ckGrand
            // 
            this.ckGrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckGrand.AutoSize = true;
            this.ckGrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckGrand.Location = new System.Drawing.Point(427, 81);
            this.ckGrand.Name = "ckGrand";
            this.ckGrand.Size = new System.Drawing.Size(108, 28);
            this.ckGrand.TabIndex = 23;
            this.ckGrand.TabStop = true;
            this.ckGrand.Text = "الجمع الكبرى";
            this.ckGrand.UseVisualStyleBackColor = true;
            this.ckGrand.CheckedChanged += new System.EventHandler(this.ckGrand_CheckedChanged);
            // 
            // treeVLecteur
            // 
            this.treeVLecteur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeVLecteur.CheckBoxes = true;
            this.treeVLecteur.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVLecteur.Indent = 30;
            this.treeVLecteur.Location = new System.Drawing.Point(108, 115);
            this.treeVLecteur.Name = "treeVLecteur";
            this.treeVLecteur.RightToLeftLayout = true;
            this.treeVLecteur.Size = new System.Drawing.Size(427, 287);
            this.treeVLecteur.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(537, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "اختيار القراء";
            // 
            // txt_nom
            // 
            this.txt_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nom.Location = new System.Drawing.Point(409, 48);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(126, 26);
            this.txt_nom.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(541, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "اسم الرموز";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(635, 39);
            this.label1.TabIndex = 24;
            this.label1.Text = "اضافة رموز القراء";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(7, 419);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 34);
            this.btClose.TabIndex = 27;
            this.btClose.Text = "غلق";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btAjout
            // 
            this.btAjout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAjout.Location = new System.Drawing.Point(542, 419);
            this.btAjout.Name = "btAjout";
            this.btAjout.Size = new System.Drawing.Size(73, 34);
            this.btAjout.TabIndex = 28;
            this.btAjout.Text = "اضافة";
            this.btAjout.UseVisualStyleBackColor = true;
            this.btAjout.Click += new System.EventHandler(this.btAjout_Click);
            // 
            // Frm_CodeLecteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 452);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAjout);
            this.Controls.Add(this.txt_nom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckPetit);
            this.Controls.Add(this.ckGrand);
            this.Controls.Add(this.treeVLecteur);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_CodeLecteur";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رموز القراء";
            this.Load += new System.EventHandler(this.Frm_CodeLecteur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ckPetit;
        private System.Windows.Forms.RadioButton ckGrand;
        private System.Windows.Forms.TreeView treeVLecteur;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_nom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btAjout;
    }
}