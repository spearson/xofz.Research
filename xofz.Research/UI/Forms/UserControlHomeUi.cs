namespace xofz.Research.UI.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI.Forms;

    public partial class UserControlHomeUi : UserControlUi, HomeUi
    {
        public UserControlHomeUi(
            Func<List<TextBox>, MaterializedEnumerable<TextBox>> materializeTextBoxes,
            Func<LinkedList<int>, MaterializedEnumerable<int>> materializeNumbers)
        {
            this.materializeNumbers = materializeNumbers;
            InitializeComponent();
            this.numbersTextBoxes =
                materializeTextBoxes(
                    new List<TextBox>(15)
                    {
                        this.n1TextBox,
                        this.n2TextBox,
                        this.n3TextBox,
                        this.n4TextBox,
                        this.n5TextBox,
                        this.n6TextBox,
                        this.n7TextBox,
                        this.n8TextBox,
                        this.n9TextBox,
                        this.n10TextBox,
                        this.n11TextBox,
                        this.n12TextBox,
                        this.n13TextBox,
                        this.n14TextBox,
                        this.n15TextBox,
                    });

            var h = this.Handle;
        }

        public event Action GenerateKeyTapped;

        public event Action RotateKeyTapped;

        bool HomeUi.RandomizeRotations
        {
            get { return this.randomizeCheckBox.Checked; }

            set { this.randomizeCheckBox.Checked = value; }
        }

        int HomeUi.MaxValue
        {
            get { return int.Parse(this.maxValueTextBox.Text); }

            set { this.maxValueTextBox.Text = value.ToString(); }
        }

        int HomeUi.NumberOfRotations
        {
            get { return int.Parse(this.rotationsTextBox.Text); }

            set { this.rotationsTextBox.Text = value.ToString(); }
        }

        public MaterializedEnumerable<int> Numbers
        {
            get
            {
                var ll = new LinkedList<int>();
                foreach (var tb in this.numbersTextBoxes)
                {
                    ll.AddLast(int.Parse(tb.Text));
                }

                return this.materializeNumbers(ll);
            }

            set
            {
                var enumerator = this.numbersTextBoxes.GetEnumerator();
                foreach (var number in value)
                {
                    enumerator.MoveNext();
                    enumerator.Current.Text = number.ToString();
                }
            }
        }

        private void generateKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.GenerateKeyTapped?.Invoke()).Start();
        }

        private void rotateKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.RotateKeyTapped?.Invoke()).Start();
        }

        private readonly MaterializedEnumerable<TextBox> numbersTextBoxes;
        private readonly Func<LinkedList<int>, MaterializedEnumerable<int>> materializeNumbers;
    }
}
