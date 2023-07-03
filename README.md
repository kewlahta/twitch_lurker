# twitch_lurker
Application for continually refreshing/reloading a Twitch channel to be the ultimate lurker 24x7.

This is an old application written several years ago. The application is a C# forms app that allows the user to enable/disable an ultimate lurk mode. The program starts a background task that scans running processes on a schedule, kills any chrome or firefox processes, then restarts the system's default browser pointed towards a target Twitch channel. The browser invocation uses an endpoint that forces the volume of the channel down to an unnoticeable level.

At the time of writing, racking up view time on a Twitch channel required the user session be active and the browser tab unmuted. Force closing the browser and re-opening allowed for the user session to remain constantly active and ensured the correct channel was loaded. This approach also solved the issue of leaving a browsing session unattended and the streamer raiding another Twitch user. 

## Disclaimer
This application may or may not work. The target channel and schedule interval is hard coded into the url in the Form1.cs file. This application was never meant to be used other than as a proof of concept so it's far from elegant. Using this code could (unknown) result in a Twitch user ban if the activity is considered a violation of Twitch's TOS. 