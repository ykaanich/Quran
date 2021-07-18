namespace Quran
{
    partial class Frm_Classeur
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
            this.ckSelecetAll = new System.Windows.Forms.CheckBox();
            this.treeVLecteur = new System.Windows.Forms.TreeView();
            this.txt_nom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btAjout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_remarque = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckGrand = new System.Windows.Forms.RadioButton();
            this.ckPetit = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ckSelecetAll
            // 
            this.ckSelecetAll.AutoSize = true;
            this.ckSelecetAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSelecetAll.Location = new System.Drawing.Point(22, 216);
            this.ckSelecetAll.Name = "ckSelecetAll";
            this.ckSelecetAll.Size = new System.Drawing.Size(77, 21);
            this.ckSelecetAll.TabIndex = 16;
            this.ckSelecetAll.Text = "اختيار الكل";
            this.ckSelecetAll.UseVisualStyleBackColor = true;
            this.ckSelecetAll.Visible = false;
            // 
            // treeVLecteur
            // 
            this.treeVLecteur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeVLecteur.CheckBoxes = true;
            this.treeVLecteur.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVLecteur.Indent = 30;
            this.treeVLecteur.Location = new System.Drawing.Point(131, 216);
            this.treeVLecteur.Name = "treeVLecteur";
            this.treeVLecteur.RightToLeftLayout = true;
            this.treeVLecteur.Size = new System.Drawing.Size(402, 287);
            this.treeVLecteur.TabIndex = 15;
            this.treeVLecteur.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeVLecteur_AfterCheck);
            // 
            // txt_nom
            // 
            this.txt_nom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nom.Location = new System.Drawing.Point(22, 45);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(511, 26);
            this.txt_nom.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(535, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "اختيار القراء";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(532, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "اسم الكراس";
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(0, 500);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 34);
            this.btClose.TabIndex = 8;
            this.btClose.Text = "غلق";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btAjout
            // 
            this.btAjout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAjout.Location = new System.Drawing.Point(558, 500);
            this.btAjout.Name = "btAjout";
            this.btAjout.Size = new System.Drawing.Size(73, 34);
            this.btAjout.TabIndex = 9;
            this.btAjout.Text = "اضافة";
            this.btAjout.UseVisualStyleBackColor = true;
            this.btAjout.Click += new System.EventHandler(this.btAjout_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(632, 39);
            this.label1.TabIndex = 7;
            this.label1.Text = "كراس العمل";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_remarque
            // 
            this.txt_remarque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_remarque.Location = new System.Drawing.Point(22, 86);
            this.txt_remarque.Multiline = true;
            this.txt_remarque.Name = "txt_remarque";
            this.txt_remarque.Size = new System.Drawing.Size(511, 90);
            this.txt_remarque.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(555, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "الملاحظات";
            // 
            // ckGrand
            // 
            this.ckGrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckGrand.AutoSize = true;
            this.ckGrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckGrand.Location = new System.Drawing.Point(425, 182);
            this.ckGrand.Name = "ckGrand";
            this.ckGrand.Size = new System.Drawing.Size(108, 28);
            this.ckGrand.TabIndex = 19;
            this.ckGrand.TabStop = true;
            this.ckGrand.Text = "الجمع الكبرى";
            this.ckGrand.UseVisualStyleBackColor = true;
            this.ckGrand.CheckedChanged += new System.EventHandler(this.ckGrand_CheckedChanged);
            // 
            // ckPetit
            // 
            this.ckPetit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckPetit.AutoSize = true;
            this.ckPetit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPetit.Location = new System.Drawing.Point(131, 182);
            this.ckPetit.Name = "ckPetit";
            this.ckPetit.Size = new System.Drawing.Size(119, 28);
            this.ckPetit.TabIndex = 19;
            this.ckPetit.TabStop = true;
            this.ckPetit.Text = "الجمع الصغرى";
            this.ckPetit.UseVisualStyleBackColor = true;
            this.ckPetit.CheckedChanged += new System.EventHandler(this.ckPetit_CheckedChanged);
            // 
            // Frm_Classeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(632, 534);
            this.Controls.Add(this.ckPetit);
            this.Controls.Add(this.ckGrand);
            this.Controls.Add(this.txt_remarque);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ckSelecetAll);
            this.Controls.Add(this.treeVLecteur);
            this.Controls.Add(this.txt_nom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAjout);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Frm_Classeur";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كراس العمل";
            this.Load += new System.EventHandler(this.Frm_Classeur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckSelecetAll;
        private System.Windows.Forms.TreeView treeVLecteur;
        private System.Windows.Forms.TextBox txt_nom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btAjout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_remarque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton ckGrand;
        private System.Windows.Forms.RadioButton ckPetit;
    }
}