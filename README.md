## ExtendedControls
A set of WinForms user controls written in C# to extend WinForms functionality

**Usage** Add ExtendedControls.dll as reference to your WinForms project.
***

### **StatusBox**
**On click cycles through an index of various statuses.**

Similar behaviour to a *checkBox* or a *comboBox* but displays just a small icon to display current status.
* On click when `Interactive = true` StatusBox cycles to the next status.
* If final status is reached then it restarts at index 0.
* Each Status is defined with a *description* and an *icon* and then stored in Statuses.
* Access with `StatusBox.Value` to get or set current index value.
* By default loaded with *pending*, *in_progress*, *paused*, *complete*, *cancelled*.
* Can be loaded with as many *Statuses* as you wish and default ones can be removed from list or re-ordered.
***

*Created for one of my private projects but felt like a good idea to share with the world as having easy access to useful controls makes producing awesome software quicker and easier*
