<img src="https://github.com/TorniX0/OpenTimerResolution/raw/main/src/program.ico" width="150" height="150">

# OpenTimerResolution

<img src="https://github.com/TorniX0/OpenTimerResolution/raw/main/repo_imgs/OpenTimerResolution_preview.png" width="603.8461538461538" height="278.4615384615385">

OpenTimerResolution is a lightweight open-source application that changes the resolution of the Windows system Timer to a specified value and has a memory cache cleaner included.

There's also the option to run it at startup minimized (since v1.0.2.0). 
Running the program with the `-minimized` argument will start the program, force the timer resolution (specified in the config file, default `0.5`), enable/disable the memory cache cleaner automatically (specified in the config file, default `true`) (since v1.0.3.1) and minimize itself to tray. 

You can log the actual resolution of the Windows system Timer, then save it into a `.log` file. (since v1.0.2.3)

<img src="https://github.com/TorniX0/OpenTimerResolution/raw/main/repo_imgs/dark_mode.gif" width="603.8461538461538" height="278.4615384615385">
You can also enable dark mode (since v1.0.2.4).

You can also silently install the start-up schedule (if not already) using the `-silentInstall` argument, and start minimized. (since v1.0.3.5)

OpenTimerResolution will automatically check (and install if prompted) for new versions available on GitHub at startup (not using any external sources). (since v1.0.3.6)

**In order for the program to take effect, it needs to be running in the background.** 

**Small note: The automatic memory cache cleaner might slow down downloads on apps such as Steam (when downloading or updating).**

.NET 6.0 SDK is required to build the project: https://dotnet.microsoft.com/download/dotnet/6.0

# License

This project is licensed under the GNU General Public License version 2 ("GPLv2") and therefore can be used in commercial projects. However, any commit or change to the main code must be public and there should be a copyright notice in the source code clarifying the license and its terms as part of your project as well as a hyperlink to this repository. This program is distributed in the hope that it will be useful. [Read more about GPLv2](https://www.gnu.org/licenses/old-licenses/gpl-2.0.en.html).

**THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.**
