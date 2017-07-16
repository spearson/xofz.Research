namespace xofz.Research.UI.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI.Forms;

    public partial class UserControlRotationUi : UserControlUi, RotationUi
    {
        public UserControlRotationUi(Materializer materializer)
        {
            this.materializer = materializer;
            this.InitializeComponent();
            this.numbersTextBoxes =
                this.materializer.Materialize(
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
        }

        public event Action GenerateKeyTapped;

        public event Action RotateLeftKeyTapped;

        public event Action RotateRightKeyTapped;

        bool RotationUi.RandomizeRotations
        {
            get => this.randomizeCheckBox.Checked;

            set => this.randomizeCheckBox.Checked = value;
        }

        int RotationUi.MaxValue
        {
            get => int.Parse(this.maxValueTextBox.Text);

            set => this.maxValueTextBox.Text = value.ToString();
        }

        int RotationUi.NumberOfRotations
        {
            get => int.Parse(this.rotationsTextBox.Text);

            set => this.rotationsTextBox.Text = value.ToString();
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

                return this.materializer.Materialize(ll);
            }

            set
            {
                var enumerator = this.numbersTextBoxes.GetEnumerator();
                foreach (var number in value)
                {
                    enumerator.MoveNext();
                    enumerator.Current.Text = number.ToString();
                }

                enumerator.Dispose();
            }
        }

        private void generateKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.GenerateKeyTapped?.Invoke()).Start();
        }

        private void rotateRightKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.RotateRightKeyTapped?.Invoke()).Start();
        }

        private void rotateLeftKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.RotateLeftKeyTapped?.Invoke()).Start();
        }

        private readonly Materializer materializer;
        private readonly MaterializedEnumerable<TextBox> numbersTextBoxes;
    }
}
