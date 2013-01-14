# NationStates AutoTelegram #

## Introduction ##
NationStates AutoTelegram automatically sends telegrams to NationStates nations.

## Documentation ##

### System Requirements ###
* The [.NET Framework 4 Full](http://www.microsoft.com/download/en/details.aspx?id=17851)
* A [NationStates](http://www.nationstates.net) nation
* An email address

### Tutorial ###
1. Click on the tab labeled *Telegram Text*, then type your telegram in the textbox below.
	* If you type `%NATION%` or `%REGION%` in the telegram, the program will replace it with the recipient's name and region respectively when sending the telegram.
	* Please keep in mind that this program is not a text editor, and has a limited number of text-editing features.
2. Click on the tab labeled *Sender*, and type in your NationStates account information.
	* Your email address is required in addition to your username and password so that the NationStates administrators can contact you in the event of a problem with the program.
3. Click on the tab labeled *Recipients*, and type in the recipients of the telegram.
	* A telegram sent to a "region" is sent to all nations within that region, unless stated otherwise.
	* A telegram sent to a "tag" is sent to all nations in regions with that tag, unless stated otherwise.
	* Telegrams will be sent to all nations, regions and tags specified in their respective *Include* fields or by their respective *Include* checkboxes. 
	* Telegrams will not be sent to all nations, regions and tags specified in their respective *Exclude* fields or by their respective *Exclude* checkboxes, **even if explicitly included elsewhere**.
	* The *Limit to World Assembly member nations* and *Limit to regional delegates* checkboxes under each field remove all non-WA nations or non-regional delegates from the field above.
	* Note that the *Include all nations* checkbox uses the nations daily data dump, so the information may be out-of-date by up to 24 hours. (All other options use the API, which is always up-to-date.)
	* When nations, regions and tags are entered into fields, they should be separated by commas. Spaces between items are optional.
4. Click on the *Send Telegram* button, and send the telegrams by clicking *Start*.
	* You should always save the log after the process completes by right-clicking the log and clicking *Save As*, in case there is a problem with the program.
	* You can cancel the telegramming process at any time by pressing *Cancel*. There may be a delay before the process is cancelled since it is running on a separate thread.
	* You can pause the telegramming process by clicking *Pause*. Click *Resume* to resume the process. Again, there may be a delay before the process is paused or resumed.

#### Technical ####
* This program reports its UserAgent to the NationStates API as follows:
	`NationStates AutoTelegram <version>
	Program author (not responsible for use): Auralia (federal.republic.of.auralia@gmail.com)
	Current user (responsible for use): <username> (<email>)`

## Changelog ##
* Version 0.3.1:
	* Bug fixes
* Version 0.3.0:
	* UI redesign
	* Bug fixes
	* Performance improvements
	* Simplification and reformatting of code base
    * Updates to readme and license
	* Certain features removed
* Version 0.2.2:
	* Bug fixes
* Version 0.2.1:
	* Bug fixes
* Version 0.2:
	* %NATION% menu option
	* %REGION% feature and menu option
	* WA nations option on recipient dialog
	* Pause button
	* Cosmetic changes
	* Bug fixes
* Version 0.1:
	* Initial public release

## Copyright and License ##
Copyright (C) [Auralia](http://www.nationstates.net/nation=auralia).

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

You must read and understand the [NationStates mass telegramming and scripting rules](http://forum.nationstates.net/viewtopic.php?f=16&t=74486) before using the Software. You agree that the author of the Software is not responsible for any breaches of NationStates rules resulting from your use of the Software.

This program includes [code from Coffee and Crack](http://forum.nationstates.net/viewtopic.php?p=8502718) and [code from Microsoft](http://msdn.microsoft.com/en-us/library/01escwtf.aspx).

This program uses icons from the [Silk Icon Set](http://www.famfamfam.com/lab/icons/silk/) and the [Tango Desktop Project](http://tango.freedesktop.org/).