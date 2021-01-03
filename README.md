# ExtendedControls
A set of WinForms user controls written in C# to extend WinForms functionality

## Usage
Add ExtendedControls.dll as reference to your WinForms project.

## Controls
### StatusBox
#### Holds an index of various statuses.
* On click when `Interactive = true` StatusBox cycles to the next status.
* If final status is reached then it restarts at index 0.
* Each Status is defined with a description and an icon stored in Statuses.
* Access with `StatusBox.Value` to get or set current index value.

*Created for one of my private projects but felt like a good idea to share with the world as having easy access to useful controls makes producing awesome software quicker and easier*
