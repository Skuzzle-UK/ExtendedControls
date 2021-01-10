## ExtendedControls
A set of .NETFramework WinForms user controls written in C# to extend WinForms functionality
Some of these controls will successfully port into a .NET Core WinForms app with a little work.

**Please feel free to start adding your own** or even just add ideas for controls that you are looking for and we can have a look at creating for you.

**Usage** Add ExtendedControls.dll as reference to your WinForms project or import just an individual control .cs
If importing a control singularly, some controls may require you to import their entire folder so as to copy in resources and modify file paths inside the c# code.
Visual studio will bring this to your attention as an error at compile time.
***

### **StatusBox**
**On click cycles through an index of various statuses.**

Similar behaviour to a *checkBox* or a *comboBox* but displays just a small icon to display current status.
* On click when `Interactive = true` StatusBox cycles to the next status.
* If final status is reached then it restarts at index 0.
* Each Status is defined with a *description* and an *icon* and then stored in Statuses.
* Access with `StatusBox.Value` to get or set current index value.
* Access with `StatusBox.Selected` to get current status description string.
* By default loaded with *pending*, *in_progress*, *paused*, *complete*, *cancelled*.
* Can be loaded with as many *Statuses* as you wish and default ones can be removed from list or re-ordered.
* To fit in with original design it is suggested that *icon* image files should be 100x100 px with 7px transparent padding.
***

*Created for one of my private projects but felt like a good idea to share with the world as having easy access to useful controls makes producing awesome software quicker and easier*
