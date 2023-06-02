import os.path
import sys
import json
import urllib
from moviepy.editor import *
from moviepy.video.tools.subtitles import *
import ast


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

codecDictionary = {
"avi" : "libx264",
"mp4": "libx264",
"ogv": "libtheora",
"webm": "libvpx",
"ogg": "libvorbis",
"mp3": "pcm_s16le",
"wav": "libvorbis",
"m4a": "libfdk_aac",
"mkv" : "libx264"
}

moiveUrl = data["movUrl"]
moiveType = data["moiveType"]
sceneName = data["sceneName"]
sceneUrl = data["sceneUrl"]
startTime = data["startTime"]
endTime = data["endTime"]
subtitleUrl = data["subtitleUrl"]



_moiveUrl = urllib.parse.unquote(moiveUrl)
_sceneUrl = urllib.parse.unquote(sceneUrl)
_subtitleUrl = urllib.parse.unquote(subtitleUrl)





generator = lambda txt: TextClip(txt, font='Arial', fontsize=30, color='white')
subtitleFile = file_to_subtitles(_subtitleUrl)
subtitleArr = []
for x in subtitleFile:
    times = x[0]
    line = x[1]
    if type(times) == list:
        subtitleArr.append(((times[0], times[1]), line))

moive = VideoFileClip(_moiveUrl)
subtitle = SubtitlesClip(subtitleArr, generator)

compositeMoive = CompositeVideoClip([moive, subtitle.set_position(('center', 'bottom'))])
compositeMoiveClip = compositeMoive.subclip(startTime,endTime)
pathForSave = os.path.join(_sceneUrl, sceneName + "." + moiveType)


try:
    compositeMoiveClip.write_videofile(pathForSave, codec=codecDictionary[moiveType], threads=8, fps=24)
   

except:
    try:
         compositeMoiveClip.write_videofile(pathForSave, threads=8, fps=24)
    except :
        compositeMoiveClip.write_videofile(pathForSave, codec=codecDictionary["mp4"], threads=8, fps=24)






    

    
moive.close()
subtitle.close()
compositeMoive.close()

