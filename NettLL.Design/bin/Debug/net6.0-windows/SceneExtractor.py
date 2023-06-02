import os.path
import sys
import urllib
from moviepy.editor import *

moiveUrl = str(sys.argv[1])
moiveType = str(sys.argv[2])
sceneName = str(sys.argv[3])
sceneUrl = str(sys.argv[4])
startTime = str(sys.argv[5])
endTime = str(sys.argv[6])

print("url : " +  moiveUrl)
print("moiveType : " +  moiveType)
print("sceneName : " +  sceneName)
print("sceneUrl : " +  sceneUrl)
print("startTime : " +  startTime)
print("endTime : " +  endTime)
#arr =startTime.split(":")
#startTime = arr[0]+":"+arr[1]+":"+arr[2].split(",")[0]
#arr =endTime.split(":")
#endTime = arr[0]+":"+arr[1]+":"+arr[2].split(",")[0]
_moiveUrl= urllib.parse.unquote(moiveUrl)
_sceneUrl= urllib.parse.unquote(sceneUrl)

moive = VideoFileClip(_moiveUrl)
moiveClip = moive.subclip(startTime, endTime)
pathForSave = os.path.join(_sceneUrl, sceneName + "." + moiveType)
moiveClip.write_videofile(pathForSave)
moiveClip.close()
