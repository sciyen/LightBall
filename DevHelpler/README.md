# How to enable audio in WSL environment
Refer to this https://community.mycroft.ai/t/experimental-mycroft-on-wsl-with-pulseaudio/5464
WSL pass audio with TCP 127.0.0.1, so you need a pulseaudio server on Windows, and you need to install pulseaudio in WSL.
1. pulseaudio
In ubuntu terminal: sudo apt-get install pulseaudio
In ubuntu terminal: export PULSE_SERVER=tcp:127.0.0.1
You can add it into your .bashrc

2. Install pulseaudio server on Windows 
Download Pulseaudio 1.1 windows binary from http://bosmans.ch/pulseaudio/pulseaudio-1.1.zip

Edit the file .\etc\pulse\default.pa
Replace the following line `#load-module module-native-protocol-tcp` with `load-module module-native-protocol-tcp auth-ip-acl=127.0.0.1`

Edit the file .\etc\pulse\daemon.conf
Replace the following line `; exit-idle-time = 20` with `exit-idle-time = -1`

3. Run the server
Run .\bin\pulseaudio.exe

# How to enable x application
Refer to https://research.wmz.ninja/articles/2017/11/setting-up-wsl-with-graphics-and-audio.html
