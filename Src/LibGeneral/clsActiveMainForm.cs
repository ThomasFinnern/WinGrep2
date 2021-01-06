using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace LibWindowsForms
{
    // ToDo Use for clsActiveMainForm ==> public class GenericList<T> where T : Employee
    public class clsActiveMainForm
    {

        public static Form SearchMdiParentForm()
        {
            // ToDo: try catch
            FormCollection openForms = Application.OpenForms;
            for (int i = 0; i < openForms.Count; ++i) // && activeForm == null
            {
                Form openForm = openForms[i];
                if (openForm.IsMdiContainer)
                {
                    return openForm;
                }
            }

            return null;
        }

        public static Form SearchActiveMdiChildForm()
        {
            // ToDo: try catch
            FormCollection openForms = Application.OpenForms;
            for (int i = 0; i < openForms.Count; ++i) // && activeForm == null
            {
                Form openForm = openForms[i];
                if (openForm.IsMdiContainer)
                {
                    return openForm.ActiveMdiChild;
                }
            }

            return null;
        }

        public static Form SearchActiveMdiChildForm(Form MdiProgramParentForm)
        {
            //---------------------------------------------------------------
            // Find active search result window and start search there
            //---------------------------------------------------------------

            // Create an instance of a form and assign it the currently active form.
            // Form activeForm = Form.ActiveForm;
            //Form activeForm = this.ActiveMdiChild;
            Form activeForm = MdiProgramParentForm.ActiveMdiChild;

            if (activeForm == null)
            {
                FormCollection openForms = Application.OpenForms;
                for (int i = 0; i < openForms.Count && activeForm == null; ++i)
                {
                    Form openForm = openForms[i];
                    if (openForm.IsMdiContainer)
                    {
                        activeForm = openForm.ActiveMdiChild;
                    }
                }
            }

            return activeForm;
        }
    }
}
