## ExtendedControls
A set of .NETFramework WinForms user controls written in C# to extend WinForms functionality
Some of these controls will successfully port into a .NET Core WinForms app with a little work.

**Please feel free to start adding your own** or even just add ideas for controls that you are looking for and we can have a look at creating for you.

**Usage** Add ExtendedControls.dll as reference to your WinForms project or import just an individual control .cs
If importing a control singularly, some controls may require you to import their entire folder so as to copy in resources and modify file paths inside the c# code.
Your IDE will usually bring this to your attention as an error at compile time.
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

### **TextBoxExtended**
**Similar behaviour to a normal TextBox but with extra options.**

**Extended options / behaviours**
* **Padding** - `TextBoxExtended.PadTop`, `TextBoxExtended.PadBottom`, `TextBoxExtended.PadLeft`, `TextBoxExtended.PadRight` to get or set padding sizes.

* **Padding Color** - `TextBoxExtended.PadTopColor`, `TextBoxExtended.PadBottomColor`, `TextBoxExtended.PadLeftColor`, `TextBoxExtended.PadRightColor` to get or set padding colours.

*New options / behaviours are exposed to the IDE's control properties window.*
***

### **PriceBox**
**Price formatted version of TextBoxExtended with a decimal Value accessor.**
* Displays currency symbol of local computers system locale if `PriceBox.Currency = null`.
* Currency display can be forced through the PriceBox.Currency string which will reject over 3 characters.
* Forces 2 decimal places on all values entered.
* Only allows numeric values to be entered and only one point followed by 2 decimal places.
* Defaults to display 0.00 if null value.
* `PriceBox.Value` sets and returns a decimal value.
* Example access `decimal basket_total_price = PriceBox.Value;`
* Example set `PriceBox.Value = 17.47;`
***

### **ComboBoxExtended**
* WIP
***

*Created for one of my private projects but felt like a good idea to share with the world as having easy access to useful controls makes producing awesome software quicker and easier*
