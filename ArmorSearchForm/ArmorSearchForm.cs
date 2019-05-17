using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using ArmorDBModel;

namespace ArmorSearchForm
{
    public partial class ArmorSearchForm : Form
    {
        public ArmorSearchForm()
        {
            InitializeComponent();
        }

        private void ArmorSearchForm_Load(object sender, EventArgs e)
        {
            db.Skills.Load();
            skillBindingSource.DataSource = db.Skills.Local.ToBindingList();

            //generate 5 DDs on startup
            comboBox1.SelectedItem = null;
            Skill_DDs.Add(comboBox1);
            Point_DDs.Add(comboBox2);
            Source_DDs.Add(skillBindingSource);
            for (int i = 0; i < 4; i++)
            {
                CreateSkillDD();
                CreatePointDD();
            }

        }

        ArmorDBEntities db = new ArmorDBEntities();
        List<ComboBox> Skill_DDs = new List<ComboBox>();
        List<ComboBox> Point_DDs = new List<ComboBox>();
        List<BindingSource> Source_DDs = new List<BindingSource>();

        private void CreateSkillDD()
        {
            //Create new space in Skills_List for selected Skill object

            //Create new data source for the drop down
            Source_DDs.Add(new BindingSource(this.components));
            ((System.ComponentModel.ISupportInitialize)(Source_DDs.ElementAt(Source_DDs.Count - 1))).BeginInit();
            Source_DDs.ElementAt(Source_DDs.Count - 1).DataSource = typeof(ArmorDBModel.Skill);
            ((System.ComponentModel.ISupportInitialize)(Source_DDs.ElementAt(Source_DDs.Count - 1))).EndInit();
            Source_DDs.ElementAt(Source_DDs.Count - 1).DataSource = db.Skills.Local.ToBindingList();

            //Create new drop down for skill (mostly copied from designer.cs)
            Skill_DDs.Add(new ComboBox());
            Skill_DDs.ElementAt(Skill_DDs.Count - 1).DisplayMember = "SkillName";
            Skill_DDs.ElementAt(Skill_DDs.Count - 1).FormattingEnabled = true;
            Skill_DDs.ElementAt(Skill_DDs.Count - 1).Location = new System.Drawing.Point(79, Skill_DDs.ElementAt(Skill_DDs.Count - 2).Location.Y + 25);
            Skill_DDs.ElementAt(Skill_DDs.Count - 1).Name = "Generated Combo Box";
            Skill_DDs.ElementAt(Skill_DDs.Count - 1).Size = new System.Drawing.Size(138, 21);
            Skill_DDs.ElementAt(Skill_DDs.Count - 1).TabIndex = 0;
            Skill_DDs.ElementAt(Skill_DDs.Count - 1).ValueMember = "SkillID";
            this.Controls.Add(Skill_DDs.ElementAt(Skill_DDs.Count - 1));
            Skill_DDs.ElementAt(Skill_DDs.Count - 1).DataSource = Source_DDs.ElementAt(Source_DDs.Count - 1);
            Skill_DDs.ElementAt(Skill_DDs.Count - 1).SelectedItem = null;
            Skill_DDs.ElementAt(Skill_DDs.Count - 1).SelectedIndexChanged += this.ComboBox1_SelectedIndexChanged;
        }

        private void CreatePointDD()
        {
            Point_DDs.Add(new ComboBox());
            Point_DDs.ElementAt(Point_DDs.Count - 1).FormattingEnabled = true;
            Point_DDs.ElementAt(Point_DDs.Count - 1).Location = new System.Drawing.Point(222, Point_DDs.ElementAt(Point_DDs.Count - 2).Location.Y + 25);
            Point_DDs.ElementAt(Point_DDs.Count - 1).Name = "Generated Combo Box";
            Point_DDs.ElementAt(Point_DDs.Count - 1).Size = new System.Drawing.Size(37, 21);
            Point_DDs.ElementAt(Point_DDs.Count - 1).TabIndex = 0;
            this.Controls.Add(Point_DDs.ElementAt(Point_DDs.Count - 1));
        }

        private void DeleteLastDDs()
        {
            int last = Skill_DDs.Count - 1;
            Source_DDs.ElementAt(last).Dispose();
            Skill_DDs.ElementAt(last).Dispose();
            Point_DDs.ElementAt(last).Dispose();
            Source_DDs.RemoveAt(last);
            Skill_DDs.RemoveAt(last);
            Point_DDs.RemoveAt(last);
        }

        private void FillPointsDD(int index, long max_points)
        {
            Point_DDs.ElementAt(index).Items.Clear();
            for (int i = 1; i <= max_points; i++)
            {
                Point_DDs.ElementAt(index).Items.Add(i);
            }
            Point_DDs.ElementAt(index).SelectedItem = 1;
            Point_DDs.ElementAt(index).Focus();
            if (max_points > 1)
            {
                Point_DDs.ElementAt(index).DroppedDown = true;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                //checks that this is the last DD that's open (so changing other DDs doesn't spawn new DDs)
                bool all_contain = true;
                for (int i = 0; i < Skill_DDs.Count; i++)
                {
                    if (Skill_DDs.ElementAt(i).SelectedItem == null)
                    {
                        all_contain = false;
                    }
                }
                if ((Skill_DDs.Count <= 20) && all_contain)
                {
                    //Create new DDs for Skill and Points, then move buttons if necessary
                    CreateSkillDD();
                    CreatePointDD();
                }

                //populates Point DD based on max points of selected item in Skill DD
                long max_points = db.Skills.Find((sender as ComboBox).SelectedValue).MaxPoints;
                FillPointsDD(Skill_DDs.IndexOf(sender as ComboBox), max_points);
            }
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (Skill_DDs.Count <= 20)
            {
                //Create new DDs for Skill and Points, then move buttons if necessary
                CreateSkillDD();
                CreatePointDD();
            }
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (Skill_DDs.Count > 5)
            {
                DeleteLastDDs();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            while (Skill_DDs.Count > 5)
            {
                DeleteLastDDs();
            }

            for (int i = 0; i < 5; i++)
            {
                Skill_DDs.ElementAt(i).SelectedItem = null;
                Point_DDs.ElementAt(i).SelectedItem = null;
                Point_DDs.ElementAt(i).Items.Clear();
            }
        }

        private void QSearchButton_Click(object sender, EventArgs e)
        {
            var skillList = Skill_DDs.Where(s => s.SelectedValue != null).Select(s => long.Parse(s.SelectedValue.ToString())).ToList();

            //var selectedArmorNames = db.SetBonuses.Join(db.Armors,
            //    bonus => bonus.SetID,
            //    armor => armor.SetID,
            //    (bonus, armor) =>
            //        new { ArmorName = armor.Name, armor.ArmorID, armor.Rarity, armor.Slot1, armor.Slot2, armor.Slot3, armor.MinDef, armor.MaxDef, armor.Event,
            //                armor.Skill1ID, armor.Skill1Count, armor.Skill2ID, armor.Skill2Count, armor.Type, BonusID = bonus.SkillID})
            //   .Where(a => skillList.Contains(a .Skill1ID.Value) || skillList.Contains(a.Skill2ID.Value) || skillList.Contains(a.BonusID)).ToList();

            var selectedBonusSetIDs = db.SetBonuses
                .Where(b => skillList.Contains(b.SkillID)).ToList();

            var selectedSets = db.Sets
                .Where(s => selectedBonusSetIDs.Contains(s.SetID)).ToList();

            var selectedArmorsFromSet = db.Armors
                .Where(a => a.Set.SetBonuses.Select);

            var selectedArmorNames = db.Armors
               .Where(a => skillList.Contains(a.Skill1ID.Value) || skillList.Contains(a.Skill2ID.Value)).ToList();

            var selectedHeadPieces = selectedArmorNames.Where(a => a.Type == "helm");
            var selectedChestPieces = selectedArmorNames.Where(a => a.Type == "chest");
            var selectedArmPieces = selectedArmorNames.Where(a => a.Type == "arms");
            var selectedWaistPieces = selectedArmorNames.Where(a => a.Type == "waist");
            var selectedLegPieces = selectedArmorNames.Where(a => a.Type == "legs");
            var selectedCharmPieces = selectedArmorNames.Where(a => a.Type == "charm");
            string head_string = string.Join(",\n", selectedHeadPieces.Select(h => h.Name).ToArray());
            string chest_string = string.Join(",\n", selectedChestPieces.Select(h => h.Name).ToArray());
            string arm_string = string.Join(",\n", selectedArmPieces.Select(h => h.Name).ToArray());
            string waist_string = string.Join(",\n", selectedWaistPieces.Select(h => h.Name).ToArray());
            string leg_string = string.Join(",\n", selectedLegPieces.Select(h => h.Name).ToArray());
            string charm_string = string.Join(",\n", selectedCharmPieces.Select(h => h.Name).ToArray());

            ReturnTextBox.Text = head_string + "\n\n" + chest_string + "\n\n" + arm_string + "\n\n" + waist_string + "\n\n" + leg_string + "\n\n" + charm_string;
        }
    }

    public class RichTextBoxWithoutFocus : RichTextBox
    {
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //static extern bool HideCaret(IntPtr hWnd);
        public RichTextBoxWithoutFocus()

        {
            this.ReadOnly = true;
        }

        protected override void WndProc(ref Message m)
        {
            // Ignore all messages that try to set the focus.
            if (m.Msg != 0x7)
            {
                base.WndProc(ref m);
            }
        }
    }
}
