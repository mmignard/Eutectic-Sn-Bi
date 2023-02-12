# -*- coding: utf-8 -*-
"""
Created on Sun Feb 12 12:42:11 2023

@author: Marc
"""

import matplotlib.pyplot as plt
import numpy as np

saveImages = False
fpath = './/media//'

WptSn = np.array([100,90,80,71,64,54,47,40,33,20,10,0])

tmpts = np.genfromtxt('.//EutecticData.csv',delimiter=',',skip_header=1,unpack=True,dtype=float)

#plot just the freezing of Sn and Bi
plt.figure(figsize=(5,3),dpi=300)
plt.title('Freezing curves of Tin and Bismuth')
plt.plot(tmpts[0,:]/60,tmpts[1,:],label='Tin')
plt.plot(5.5+tmpts[0,:]/60,tmpts[12,:],label='Bismuth')
plt.grid(True)
#plt.legend()
plt.ylim([120,300])
plt.xlim([0,11])
plt.xlabel('time (min)')
plt.ylabel('temperature (degC)')
plt.annotate('Tin freezes\nat 230C', xy=(3,230), xytext=(1.5,180), arrowprops=dict(arrowstyle='->'))
plt.annotate('Bismuth freezes\nat 270C', xy=(7.5,270), xytext=(5,225), arrowprops=dict(arrowstyle='->'))
if (saveImages):
    plt.savefig(fpath+"freezingSnBi.svg", bbox_inches='tight')
plt.show()

#plot the freezing of a bunch of alloys
plt.figure(figsize=(5,3),dpi=300)
plt.title('Freezing curves of Tin and Bismuth alloys')
for w in np.arange(1,13):
    plt.plot(3.5*(w-1)+tmpts[0,:]/60,tmpts[w,:],label='Sn= {}%'.format(WptSn[w-1]))
plt.grid(True)
#plt.legend()
plt.ylim([120,280])
plt.xlim([0,45])
plt.xlabel('time (min)')
plt.ylabel('temperature (degC)')
if (saveImages):
    plt.savefig(fpath+"freezingSnBiAll.svg", bbox_inches='tight')
plt.show()

#plot the phase diagram (data collected by hand from )
phase = np.genfromtxt('.//PhaseData.csv',delimiter=',',skip_header=1,unpack=True,dtype=float)
plt.figure(figsize=(5,3),dpi=300)
plt.title('Tin/Bismuth Phase Diagram')
plt.plot(phase[0,:],phase[1,:],label='liquidus')
plt.plot(phase[0,:],phase[2,:],label='solidus')
plt.plot([0,100],[231.9,231.9],'k:',label='solidus')
plt.plot([0,100],[271.5,271.5],'k:',label='solidus')
plt.grid(True)
#plt.legend()
plt.ylim([0,300])
plt.xlim([0,100])
plt.xlabel('weight percent Bi')
plt.ylabel('temperature (degC)')
plt.text(10,235,'231.9 (Sn)')
plt.text(70,275,'271.5 (Bi)')
#plt.annotate('Tin freezes\nat 230C', xy=(3,230), xytext=(1.5,180), arrowprops=dict(arrowstyle='->'))
#plt.annotate('Bismuth freezes\nat 270C', xy=(7.5,270), xytext=(5,225), arrowprops=dict(arrowstyle='->'))
if (saveImages):
    plt.savefig(fpath+"phaseSnBi.svg", bbox_inches='tight')
plt.show()


#plotly is better for measuring the data
import plotly.express as px
import plotly.io as pio
pio.renderers.default='browser'

fig = px.line(x=tmpts[0,:]/60, y=tmpts[1,:], title='Freezing curves of Tin and Bismuth')
fig.add_scatter(x=tmpts[0,:]/60, y=tmpts[12,:])
print(fig)
fig.show()