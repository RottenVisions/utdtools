namespace UsertypeDefTools.Widget
{
	partial class BaseTypeWidget
	{
		/// <summary>
		/// Required designer variables.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up all resources that are in use.
		/// </summary>
		/// <param name="disposing">True if the managed resource should be released; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Code generated by the component designer

		/// <summary>
		/// Designer supports the required method - don't
		/// Use the code editor to modify the contents of this method.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.m_txt_name = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "TypeName:";
			//
			// m_txt_name
			//
			this.m_txt_name.Location = new System.Drawing.Point(81, 8);
			this.m_txt_name.Name = "m_txt_name";
			this.m_txt_name.ReadOnly = true;
			this.m_txt_name.Size = new System.Drawing.Size(120, 21);
			this.m_txt_name.TabIndex = 1;
			//
			// BaseTypeWidget
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.m_txt_name);
			this.Controls.Add(this.label1);
			this.Name = "BaseTypeWidget";
			this.Size = new System.Drawing.Size(227, 36);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txt_name;
	}
}