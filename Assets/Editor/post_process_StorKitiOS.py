import os
from sys import argv
from mod_pbxproj import XcodeProject

path = argv[1]

print('----------------------------------preparing to execute our magic scripts to tweak xcode project----------------------------------')
#path: /Users/khurram/Desktop/output
print('post_process.py xcode build path --> ' + path)
    
print('Step 1: start add libraries ')
project = XcodeProject.Load(path +'/Unity-iPhone.xcodeproj/project.pbxproj')
project.add_file('System/Library/Frameworks/StoreKit.framework', tree='SDKROOT', weak=True)

print('Step 2: change build setting')
project.add_other_buildsetting('GCC_ENABLE_OBJC_EXCEPTIONS', 'YES')

if project.modified:
  project.backup()
  project.saveFormat3_2()

print('----------------------------------end for excuting our magic scripts to tweak our xcode ----------------------------------')
