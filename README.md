# WinGrep2

The program **"Windows Grep"** by [Huw Millington](https://download.cnet.com/Windows-Grep/3000-2351_4-75805915.html) was a tool for searching files for text strings with a marvelous way to display the searh results in a colored HTML view for windows XP. **WinGrep2** intents to implement most features of "Windows Grep" and support some more

## History
I found "Windows Grep" around 2007 but over time there were not many news and in 2012 the development stopped. There were some features missing. I began in 2011 to create a similar exe and called it netGrepWin. I use it since for my work. As it has some pitfalls i did hold back to present it to others.

Now i intent to improve it step by step. Actually the 'old' and still nearly daily used version is kept in branch netGrepWin. Release of WinGrep2 may need a while.

## Features

### NetGrepWin Search result page

![netGrepWin Main page](https://github.com/ThomasFinnern/WinGrep2/blob/main/Documentation/netGrepWin.Main.page.png?raw=true)

### NetGrepWin Search page

![netGrepWin Search page](https://github.com/ThomasFinnern/WinGrep2/blob/main/Documentation/netGrepWin.Search.page.png?raw=true)

### Features List

* Colored search results
* Multiple forms in application so you may keep similar searches side by side
* Replacing as well as searching
* Use of regex (C# style)
* 'Search again' Key
* Saving of search results
* Command line interface
* Saving and retrieval of search criteria
* Click on file in above will open complete file with highlighted search results (Nochanges possible though)
* .
* .
*

#### Drawbacks (06.01.2021)

These points will be fixed next
* Results are not asynchron displayed and the screen freezes while searching
* Due to pre c# asyn functions the result is sometimes displayed but not acceptet -> After popup Question the results vanish but can be retrieved without search again
* Needs administrator rights due to read of config files from program folder

#### Not developed now

* Printing of search results
* Command line interface
* Saving and retrieval of search criteria
* Fully multi-tasking
* ZIP file searching
* Delimited and fixed width data file searching at field-level.
* Explorer Extension


# Disclaimer

Sorry the software is as it i. No guarantee for proper result. Especially make a backup before search and replace.
