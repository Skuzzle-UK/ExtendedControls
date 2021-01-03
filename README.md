# ExtendedControls
Set of WinForms user controls to extend winforms functionality

## Usage
* Add ExtendedControls.dll as reference to your WinForms project.

## Controls
**StatusBox** - Holds an index of various statuses.
* On click when `Interactive = true` StatusBox cycles to the next status.
* If final status is reached then it restarts at index 0.
* Each Status is defined with a description and an icon stored in Statuses.
* Access with `StatusBox.Value` to get or set current index value.
