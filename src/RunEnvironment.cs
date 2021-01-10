using System.ComponentModel;
namespace RunEnvironment
{
    class RunMode
    {
        public static bool IsInRuntimeMode(IComponent component)
        {
            bool ret = IsInDesignMode(component);
            return !ret;
        }

        public static bool IsInDesignMode(IComponent component)
        {
            bool ret = false;
            if (null != component)
            {
                ISite site = component.Site;
                if (null != site)
                {
                    ret = site.DesignMode;
                }
                else if (component is System.Windows.Forms.Control control)
                {
                    IComponent parent = control.Parent;
                    ret = IsInDesignMode(parent);
                }
            }

            return ret;
        }
    }
}
