namespace RecodeTimer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.transmit_button = new System.Windows.Forms.Button();
            this.com_combo = new System.Windows.Forms.ComboBox();
            this.com_text = new System.Windows.Forms.TextBox();
            this.enable_check1 = new System.Windows.Forms.CheckBox();
            this.enable_check2 = new System.Windows.Forms.CheckBox();
            this.enable_check3 = new System.Windows.Forms.CheckBox();
            this.start_timer1 = new System.Windows.Forms.DateTimePicker();
            this.start_timer2 = new System.Windows.Forms.DateTimePicker();
            this.start_timer3 = new System.Windows.Forms.DateTimePicker();
            this.start_text = new System.Windows.Forms.TextBox();
            this.end_time = new System.Windows.Forms.TextBox();
            this.end_timer3 = new System.Windows.Forms.DateTimePicker();
            this.end_timer2 = new System.Windows.Forms.DateTimePicker();
            this.end_timer1 = new System.Windows.Forms.DateTimePicker();
            this.receive_text = new System.Windows.Forms.TextBox();
            this.connect_button = new System.Windows.Forms.Button();
            this.disconnect_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // transmit_button
            // 
            this.transmit_button.Location = new System.Drawing.Point(542, 384);
            this.transmit_button.Name = "transmit_button";
            this.transmit_button.Size = new System.Drawing.Size(98, 30);
            this.transmit_button.TabIndex = 0;
            this.transmit_button.Text = "Transmit";
            this.transmit_button.UseVisualStyleBackColor = true;
            this.transmit_button.Click += new System.EventHandler(this.transmit_button_Click);
            // 
            // com_combo
            // 
            this.com_combo.FormattingEnabled = true;
            this.com_combo.Location = new System.Drawing.Point(48, 75);
            this.com_combo.Name = "com_combo";
            this.com_combo.Size = new System.Drawing.Size(121, 26);
            this.com_combo.TabIndex = 1;
            this.com_combo.SelectedIndexChanged += new System.EventHandler(this.com_combo_SelectedIndexChanged);
            // 
            // com_text
            // 
            this.com_text.BackColor = System.Drawing.SystemColors.Window;
            this.com_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.com_text.Location = new System.Drawing.Point(48, 51);
            this.com_text.Name = "com_text";
            this.com_text.Size = new System.Drawing.Size(100, 18);
            this.com_text.TabIndex = 2;
            this.com_text.Text = "COM Port";
            // 
            // enable_check1
            // 
            this.enable_check1.AutoSize = true;
            this.enable_check1.Location = new System.Drawing.Point(542, 170);
            this.enable_check1.Name = "enable_check1";
            this.enable_check1.Size = new System.Drawing.Size(84, 22);
            this.enable_check1.TabIndex = 3;
            this.enable_check1.Text = "Enable";
            this.enable_check1.UseVisualStyleBackColor = true;
            // 
            // enable_check2
            // 
            this.enable_check2.AutoSize = true;
            this.enable_check2.Location = new System.Drawing.Point(542, 242);
            this.enable_check2.Name = "enable_check2";
            this.enable_check2.Size = new System.Drawing.Size(84, 22);
            this.enable_check2.TabIndex = 4;
            this.enable_check2.Text = "Enable";
            this.enable_check2.UseVisualStyleBackColor = true;
            // 
            // enable_check3
            // 
            this.enable_check3.AutoSize = true;
            this.enable_check3.Location = new System.Drawing.Point(542, 314);
            this.enable_check3.Name = "enable_check3";
            this.enable_check3.Size = new System.Drawing.Size(84, 22);
            this.enable_check3.TabIndex = 5;
            this.enable_check3.Text = "Enable";
            this.enable_check3.UseVisualStyleBackColor = true;
            // 
            // start_timer1
            // 
            this.start_timer1.Location = new System.Drawing.Point(48, 170);
            this.start_timer1.Name = "start_timer1";
            this.start_timer1.Size = new System.Drawing.Size(201, 25);
            this.start_timer1.TabIndex = 6;
            // 
            // start_timer2
            // 
            this.start_timer2.Location = new System.Drawing.Point(48, 242);
            this.start_timer2.Name = "start_timer2";
            this.start_timer2.Size = new System.Drawing.Size(201, 25);
            this.start_timer2.TabIndex = 7;
            // 
            // start_timer3
            // 
            this.start_timer3.Location = new System.Drawing.Point(48, 314);
            this.start_timer3.Name = "start_timer3";
            this.start_timer3.Size = new System.Drawing.Size(201, 25);
            this.start_timer3.TabIndex = 8;
            // 
            // start_text
            // 
            this.start_text.BackColor = System.Drawing.SystemColors.Window;
            this.start_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.start_text.Location = new System.Drawing.Point(48, 146);
            this.start_text.Name = "start_text";
            this.start_text.Size = new System.Drawing.Size(100, 18);
            this.start_text.TabIndex = 9;
            this.start_text.Text = "Start Time";
            // 
            // end_time
            // 
            this.end_time.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.end_time.Location = new System.Drawing.Point(295, 146);
            this.end_time.Name = "end_time";
            this.end_time.Size = new System.Drawing.Size(100, 18);
            this.end_time.TabIndex = 10;
            this.end_time.Text = "End Time";
            // 
            // end_timer3
            // 
            this.end_timer3.Location = new System.Drawing.Point(295, 314);
            this.end_timer3.Name = "end_timer3";
            this.end_timer3.Size = new System.Drawing.Size(201, 25);
            this.end_timer3.TabIndex = 13;
            // 
            // end_timer2
            // 
            this.end_timer2.Location = new System.Drawing.Point(295, 242);
            this.end_timer2.Name = "end_timer2";
            this.end_timer2.Size = new System.Drawing.Size(201, 25);
            this.end_timer2.TabIndex = 12;
            // 
            // end_timer1
            // 
            this.end_timer1.Location = new System.Drawing.Point(295, 170);
            this.end_timer1.Name = "end_timer1";
            this.end_timer1.Size = new System.Drawing.Size(201, 25);
            this.end_timer1.TabIndex = 11;
            // 
            // receive_text
            // 
            this.receive_text.Location = new System.Drawing.Point(48, 384);
            this.receive_text.Multiline = true;
            this.receive_text.Name = "receive_text";
            this.receive_text.Size = new System.Drawing.Size(448, 95);
            this.receive_text.TabIndex = 14;
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(295, 75);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(100, 30);
            this.connect_button.TabIndex = 15;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // disconnect_button
            // 
            this.disconnect_button.Location = new System.Drawing.Point(542, 449);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(100, 30);
            this.disconnect_button.TabIndex = 16;
            this.disconnect_button.Text = "Discconect";
            this.disconnect_button.UseVisualStyleBackColor = true;
            this.disconnect_button.Click += new System.EventHandler(this.disconnect_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 500);
            this.Controls.Add(this.disconnect_button);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.receive_text);
            this.Controls.Add(this.end_timer3);
            this.Controls.Add(this.end_timer2);
            this.Controls.Add(this.end_timer1);
            this.Controls.Add(this.end_time);
            this.Controls.Add(this.start_text);
            this.Controls.Add(this.start_timer3);
            this.Controls.Add(this.start_timer2);
            this.Controls.Add(this.start_timer1);
            this.Controls.Add(this.enable_check3);
            this.Controls.Add(this.enable_check2);
            this.Controls.Add(this.enable_check1);
            this.Controls.Add(this.com_text);
            this.Controls.Add(this.com_combo);
            this.Controls.Add(this.transmit_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button transmit_button;
        private System.Windows.Forms.ComboBox com_combo;
        private System.Windows.Forms.TextBox com_text;
        private System.Windows.Forms.CheckBox enable_check1;
        private System.Windows.Forms.CheckBox enable_check2;
        private System.Windows.Forms.CheckBox enable_check3;
        private System.Windows.Forms.DateTimePicker start_timer1;
        private System.Windows.Forms.DateTimePicker start_timer2;
        private System.Windows.Forms.DateTimePicker start_timer3;
        private System.Windows.Forms.TextBox start_text;
        private System.Windows.Forms.TextBox end_time;
        private System.Windows.Forms.DateTimePicker end_timer3;
        private System.Windows.Forms.DateTimePicker end_timer2;
        private System.Windows.Forms.DateTimePicker end_timer1;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.TextBox receive_text;
        private System.Windows.Forms.Button disconnect_button;
    }
}

