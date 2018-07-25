using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UsertypeDefTools.EntityWidget
{
    public partial class MethodWindow : Form
    {
        List<EntityDef.Method> m_methods;
        EntityDef.Method m_method;
        public MethodWindow(List<EntityDef.Method> methods, EntityDef.Method method)
        {
            InitializeComponent();
            Initialize(methods, method);
        }

        void Initialize(List<EntityDef.Method> methods, EntityDef.Method method)
        {
            m_methods = methods;
            m_method = method;

            if (m_method == null)
                m_method = new EntityDef.Method();

            if (!string.IsNullOrEmpty(m_method.Name))
                m_txt_name.Text = m_method.Name;

            m_cb_exposed.Checked = m_method.Exposed;

            if (m_method.Utype.HasValue)
                m_txt_utype.Text = m_method.Utype.ToString();

            foreach (var item in BaseType.AllTypes)
                m_lb_alltypes.Items.Add(item.TypeName());

            foreach (var item in m_method.Args)
                m_lb_args.Items.Add(item.TypeName());
        }

        private void m_btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_btn_OK_Click(object sender, EventArgs e)
        {
            var name = m_txt_name.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Function name cannot be empty");
                return;
            }

            if (m_methods.Any(b => b != m_method && b.Name == name))
            {
                MessageBox.Show("Duplicate function name");
                return;
            }
            m_method.Name = name;
            m_method.Exposed = m_cb_exposed.Checked;

            UInt16 utype;
            var utypeStr = m_txt_utype.Text.Trim();
            if (!string.IsNullOrEmpty(utypeStr))
            {
                if (UInt16.TryParse(m_txt_utype.Text.Trim(), out utype))
                    m_method.Utype = utype;
                else
                {
                    MessageBox.Show("Utype must be of type UInt16");
                    return;
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void m_btn_add_Click(object sender, EventArgs e)
        {
            if (m_lb_alltypes.SelectedItem == null)
            {
                MessageBox.Show("Select a right type as the parameter type");
                return;
            }

            var typeStr = (string)m_lb_alltypes.SelectedItem;
            m_method.Args.Add(BaseType.AllTypes.Find(b => b.TypeName() == typeStr));
            m_lb_args.Items.Add(typeStr);
        }

        private void m_txt_delete_Click(object sender, EventArgs e)
        {
            if (m_lb_args.SelectedItem == null)
            {
                MessageBox.Show("Please select the parameter to delete on the left side.");
                return;
            }
            if (MessageBox.Show("Confirm delete", "Delete", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                var typeStr = (string)m_lb_args.SelectedItem;
                m_method.Args.Remove(BaseType.AllTypes.Find(b => b.TypeName() == typeStr));
                m_lb_args.Items.Remove(m_lb_args.SelectedItem);
            }
        }

        public EntityDef.Method Method
        {
            get { return m_method; }
        }
    }
}
