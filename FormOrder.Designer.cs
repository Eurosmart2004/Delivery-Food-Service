namespace DeliveryFood
{
    partial class FormOrder
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbRestaurant = new ComboBox();
            cmbFood = new ComboBox();
            quantityNum = new NumericUpDown();
            addFood = new Button();
            listFoodOrder = new ListView();
            ID = new ColumnHeader();
            FoodName = new ColumnHeader();
            Quantity = new ColumnHeader();
            PriceUnit = new ColumnHeader();
            TotalPrice = new ColumnHeader();
            label1 = new Label();
            totalPriceFood = new Label();
            btn_order = new Button();
            lsvOrder = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            cmbStatus = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            deliveryFee = new Label();
            ((System.ComponentModel.ISupportInitialize)quantityNum).BeginInit();
            SuspendLayout();
            // 
            // cmbRestaurant
            // 
            cmbRestaurant.DropDownHeight = 150;
            cmbRestaurant.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRestaurant.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            cmbRestaurant.FormattingEnabled = true;
            cmbRestaurant.IntegralHeight = false;
            cmbRestaurant.Location = new Point(116, 40);
            cmbRestaurant.Name = "cmbRestaurant";
            cmbRestaurant.Size = new Size(300, 33);
            cmbRestaurant.TabIndex = 1;
            cmbRestaurant.SelectedIndexChanged += cmbRestaurant_SelectedIndexChanged;
            // 
            // cmbFood
            // 
            cmbFood.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFood.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFood.FormattingEnabled = true;
            cmbFood.Location = new Point(119, 108);
            cmbFood.Name = "cmbFood";
            cmbFood.Size = new Size(297, 33);
            cmbFood.TabIndex = 3;
            // 
            // quantityNum
            // 
            quantityNum.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            quantityNum.Location = new Point(435, 38);
            quantityNum.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            quantityNum.Name = "quantityNum";
            quantityNum.Size = new Size(94, 32);
            quantityNum.TabIndex = 4;
            quantityNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // addFood
            // 
            addFood.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            addFood.Location = new Point(435, 108);
            addFood.Name = "addFood";
            addFood.Size = new Size(94, 35);
            addFood.TabIndex = 5;
            addFood.Text = "Add";
            addFood.UseVisualStyleBackColor = true;
            addFood.Click += addFood_Click;
            // 
            // listFoodOrder
            // 
            listFoodOrder.Columns.AddRange(new ColumnHeader[] { ID, FoodName, Quantity, PriceUnit, TotalPrice });
            listFoodOrder.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            listFoodOrder.FullRowSelect = true;
            listFoodOrder.GridLines = true;
            listFoodOrder.Location = new Point(12, 177);
            listFoodOrder.Name = "listFoodOrder";
            listFoodOrder.Size = new Size(517, 264);
            listFoodOrder.TabIndex = 6;
            listFoodOrder.UseCompatibleStateImageBehavior = false;
            listFoodOrder.View = View.Details;
            listFoodOrder.SelectedIndexChanged += listFoodOrder_SelectedIndexChanged;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 0;
            // 
            // FoodName
            // 
            FoodName.Text = "Food name";
            FoodName.Width = 150;
            // 
            // Quantity
            // 
            Quantity.Text = "Quantity";
            Quantity.Width = 120;
            // 
            // PriceUnit
            // 
            PriceUnit.Text = "Price Unit";
            PriceUnit.Width = 120;
            // 
            // TotalPrice
            // 
            TotalPrice.Text = "Total price";
            TotalPrice.Width = 120;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 506);
            label1.Name = "label1";
            label1.Size = new Size(54, 28);
            label1.TabIndex = 7;
            label1.Text = "Total";
            // 
            // totalPriceFood
            // 
            totalPriceFood.AutoSize = true;
            totalPriceFood.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            totalPriceFood.Location = new Point(116, 506);
            totalPriceFood.Name = "totalPriceFood";
            totalPriceFood.Size = new Size(23, 28);
            totalPriceFood.TabIndex = 8;
            totalPriceFood.Text = "0";
            // 
            // btn_order
            // 
            btn_order.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btn_order.Location = new Point(408, 462);
            btn_order.Name = "btn_order";
            btn_order.Size = new Size(121, 60);
            btn_order.TabIndex = 9;
            btn_order.Text = "Order";
            btn_order.UseVisualStyleBackColor = true;
            btn_order.Click += btn_order_Click;
            // 
            // lsvOrder
            // 
            lsvOrder.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            lsvOrder.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lsvOrder.FullRowSelect = true;
            lsvOrder.GridLines = true;
            lsvOrder.Location = new Point(550, 177);
            lsvOrder.Name = "lsvOrder";
            lsvOrder.Size = new Size(883, 392);
            lsvOrder.TabIndex = 10;
            lsvOrder.UseCompatibleStateImageBehavior = false;
            lsvOrder.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Restaurant name";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Shipper name";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Date";
            columnHeader3.Width = 250;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Food list";
            columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Status";
            columnHeader5.Width = 120;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(618, 108);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(297, 33);
            cmbStatus.TabIndex = 11;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(550, 111);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 12;
            label2.Text = "Status";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(550, 35);
            label3.Name = "label3";
            label3.Size = new Size(162, 35);
            label3.TabIndex = 13;
            label3.Text = "Order history";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(9, 43);
            label4.Name = "label4";
            label4.Size = new Size(101, 25);
            label4.TabIndex = 14;
            label4.Text = "Restaurant";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(9, 113);
            label5.Name = "label5";
            label5.Size = new Size(54, 25);
            label5.TabIndex = 15;
            label5.Text = "Food";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 462);
            label6.Name = "label6";
            label6.Size = new Size(83, 28);
            label6.TabIndex = 16;
            label6.Text = "Delivery";
            // 
            // deliveryFee
            // 
            deliveryFee.AutoSize = true;
            deliveryFee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            deliveryFee.Location = new Point(116, 462);
            deliveryFee.Name = "deliveryFee";
            deliveryFee.Size = new Size(23, 28);
            deliveryFee.TabIndex = 17;
            deliveryFee.Text = "0";
            // 
            // FormOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1430, 581);
            Controls.Add(deliveryFee);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbStatus);
            Controls.Add(lsvOrder);
            Controls.Add(btn_order);
            Controls.Add(totalPriceFood);
            Controls.Add(label1);
            Controls.Add(listFoodOrder);
            Controls.Add(addFood);
            Controls.Add(quantityNum);
            Controls.Add(cmbFood);
            Controls.Add(cmbRestaurant);
            Name = "FormOrder";
            Text = "Delivery food";
            ((System.ComponentModel.ISupportInitialize)quantityNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbRestaurant;
        private ComboBox cmbFood;
        private NumericUpDown quantityNum;
        private Button addFood;
        private ListView listFoodOrder;
        private ColumnHeader FoodName;
        private ColumnHeader Quantity;
        private ColumnHeader PriceUnit;
        private ColumnHeader TotalPrice;
        private Label label1;
        private Label totalPriceFood;
        private Button btn_order;
        private ColumnHeader ID;
        private ListView lsvOrder;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ComboBox cmbStatus;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label deliveryFee;
    }
}