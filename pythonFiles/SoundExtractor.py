import os.path
import sys
import json
import urllib
from moviepy.editor import *

path = str(sys.argv[1])
file=open(urllib.parse.unquote(path),"r")
seriazidData = file.read()
file.close()
print(seriazidData)
encoding = 'utf-8'
data = json.loads(seriazidData)
"""
            public string moiveName { get; set; }
            public string moiveType { get; set; }
            public string sceneName { get; set; }
            public string sceneUrl { get; set; }
            public string movUrl { get; set; }
            public string subtitleUrl { get; set; }
            public string startTime { get; set; }
            public string endTime { get; set; }
"""
moiveUrl = data["movUrl"]
moiveType = data["moiveType"]
sceneName = data["sceneName"]
sceneUrl = data["sceneUrl"]
startTime = data["startTime"]
endTime = data["endTime"]

_moiveUrl= urllib.parse.unquote(moiveUrl)
_sceneUrl= urllib.parse.unquote(sceneUrl)




moive = VideoFileClip(_moiveUrl)
moiveClip = moive.subclip(startTime, endTime)
audioClip = moiveClip.audio
pathForSave = os.path.join(_sceneUrl, sceneName + "." + "mp3")
audioClip.write_audiofile(pathForSave)
audioClip.close()
moiveClip.close()
