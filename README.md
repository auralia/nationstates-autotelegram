# NationStates AutoTelegram #

## Summary ##
NationStates AutoTelegram is a free and open source client for the NationStates Telegrams API.

## Documentation ##

### System Requirements ###
* The [.NET Framework 4 Full](http://www.microsoft.com/download/en/details.aspx?id=17851)
* A [NationStates](http://www.nationstates.net) nation
* A NationStates [API client key](http://www.nationstates.net/pages/api.html#telegrams)
* A NationStates [telegram ID and secret key](http://www.nationstates.net/pages/api.html#telegrams)

### Tutorial ###
1. Obtain an API client key, and type it into the *API client key* textbox on the *Telegram* tab page.
	* You can request an API client key from the NationStates moderators by submitting a [Getting Help Request](http://www.nationstates.net/page=help) explaining why you wish to send mass telegrams. If your request is approved, you will receive a client key by telegram. 
	* Do not share your client key with anyone.
	* If you obtain a new telegram ID and secret key (see below), you do **not** need to request a new client key.
2. Obtain a telegram ID and secret key, and type them into the *Telegram ID* and *Secret key* textboxes respectively on the *Telegram* tab page.
    * You can obtain a telegram ID and secret key by sending your telegram on NationStates to "tag:api". Make sure that you mark the telegram as a recruitment or WA campaign telegram if appropriate. After sending the telegram, you will receive a telegram ID and secret key. 
	* Do not share your secret key with anyone.
	* If you wish to change the text of your telegram, you must obtain a new telegram ID and secret key.
3. Indicate whether the telegram associated with your telegram ID is a recruitment or non-recruitment telegram by clicking the appropriate radio button, so that the appropriate rate limit can be selected.
	* The rate limit for recruitment telegrams is currently 1 telegram every 180 seconds, while the limit for non-recruitment telegrams is 1 telegram every 30 seconds.
4. Enter the recipients of your telegram into the *Recipients* textbox.
	* Recipients must be entered using the following format:
		* `nation:<nation>` : sends telegram to specified nation
		* `region:<region>` : sends telegram to all nations in specified region
		* `tag:<tag>` : sends telegrams to all nations in regions with the specified tag
		* `special:(all, members, delegates, new)` : sends telegrams to (all nations, all World Assembly members, all World Assembly delegates, 50 new nations)
		* `recruitment:new` : enables recruitment mode for new nations, which sends telegrams to new nations as they are created until the program is manually stopped; in the future this mode may support refounded nations through "recruitment:refounded"
	* Multiple recipients can be specified, separated by commas (e.g. `nation:Auralia, nation:Christian Democrats` sends telegrams to Auralia and Christian Democrats) 
	* Appending a negative sign to any recipient specifically excludes that recipient, even if explicitly included elsewhere (e.g. `region:Catholic, -nation:Auralia` will send telegrams to all nations in Catholic except Auralia).
	* The following are common usage cases:
		* Mailing list: `nation:<nation 1>, nation:<nation 2>, ... nation:<nation n>`
		* GA campaign: `members:delegates, -tag:No GA Campaigning` (note that the *No GA Campaigning* tag may be removed some time in the future due to the new telegram system's spam controls)
		* SC campaign: `members:delegates, -tag:No SC Campaigning` (note that the *No SC Campaigning* tag may be removed some time in the future due to the new telegram system's spam controls)
		* General recruitment of new nations: `recruitment:new`
4. Send your telegrams by clicking the *Start* button on the *Status* tab page.
	* You can cancel the telegramming process at any time by pressing *Cancel*. There may be a delay before the process is cancelled since it is running on a separate thread.
	* You can pause the telegramming process by clicking *Pause*. Click *Resume* to resume the process. Again, there may be a delay before the process is paused or resumed.
	* You should probably save a copy of the log after the process completes.

### Technical Information ####
* This program reports its UserAgent to the NationStates API as follows:
	`NationStates AutoTelegram <version> (maintained by Auralia, currently used by client key <client key>)`

## Changelog ##
* Version 0.4.0:
	* Support for telegrams API
	* Added recruitment mode
	* Recipient input changes
	* UI changes
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

This program uses icons from the [Silk Icon Set](http://www.famfamfam.com/lab/icons/silk/) and the [Tango Desktop Project](http://tango.freedesktop.org/).