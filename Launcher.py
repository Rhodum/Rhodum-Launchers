import urllib3
import time
import PySimpleGUI as sg
import subprocess
import base64
import json
import tkinter
import tkinter.messagebox
import sys
import time


#GUI Setting
sg.theme('LightBlue')
 
 

#important variables
currentversion = "6.0.0"
launched = "false"

# Api variables
verurl ='someurl.com'
http_pool = urllib3.connection_from_url(verurl)
verget = http_pool.urlopen('GET',verurl)




#other important variables
version = verget.data.decode('utf-8')

if version != currentversion:
    print("old launcher")
    tkinter.messagebox.showerror('Rhodum Error', 'You are using an outdated version of Rhodum, please download a new launcher.')  
    launched = "true"



#Buld the GUI
layout = [[sg.Text('Enter connection code:')],      
          [sg.Input(key='conncode')],      
          [sg.Button('Play')]]
           

window = sg.Window('Rhodum Launcher', layout)      

while launched == "false":
    event, values = window.read() 
    try:
        conncodeval = values['conncode']
    except:
        pass
    
    #Launcher security
    if conncodeval != "":
        try:
            connectioncode = base64.b64decode(conncodeval)
        except:
            tkinter.messagebox.showerror('Rhodum Error', 'Invalid code.') 
        try:
            conncodejson = json.loads(connectioncode)
        except:
            pass
        try:
            lansecurity = "someurl.com/somefile.php?key={key}&uid={uid}&gameId={gameid}".format(key=conncodejson["key"], uid=conncodejson["userid"], gameid=conncodejson["gameid"])
            http_pool = urllib3.connection_from_url(lansecurity)
            getsecrity = http_pool.urlopen('GET',lansecurity)
            launchersecurity = getsecrity.data.decode('utf-8')
            # If verification succeeded
            if launchersecurity == "yes":
                print("Launching...")
                argstobat = "{uid}:{gameid}:{key}".format(key=conncodejson["key"], uid=conncodejson["userid"], gameid=conncodejson["gameid"])
                batchpath = r'content\api\args.bat'
                launch = subprocess.Popen([batchpath, argstobat], shell=True)
                print("launched successfully")
                anticheat = "User joined: {uid} Game id:{gameid}".format(uid=conncodejson["userid"], gameid=conncodejson["gameid"])
                launched = "true"
                window.close()
                ingame = "true"
            else:
                print("invalid code")
                tkinter.messagebox.showerror('Rhodum Error', 'Rhodum iternal server error, the server replied with: {error}'.format(error=launchersecurity))  
        except:
           pass

    if event == sg.WIN_CLOSED:
        break  
