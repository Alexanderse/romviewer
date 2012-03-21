using System.Windows.Forms;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public partial class EditGameObject : Form
    {
        private GameObject _object = null;

        public EditGameObject()
        {
            InitializeComponent();
        }

        public EditGameObject(GameObject o): this()
        {
            _object = o;

            ctrlGameObject1.SetBinding(o);
        }

        public static bool PerformEdit(GameObject o)
        {
            using (EditGameObject f = new EditGameObject(o))
            {
                return (f.ShowDialog() == DialogResult.OK);
            }            
        }
    }
}
