#DirtyWall
Loads random .jpg wallpaper from <a href="http://wallhaven.cc" target="_blank">wallhaven.cc</a>

##Usage

1. Build project, then copy binaries in proper directory (<b>NOTE : this project uses <a href="https://htmlagilitypack.codeplex.com/" target="_blank">HtmlAgility Pack</a>, NuGet must be enabled during build</b>) 
2. Default config will be created at first run, edit it and run <code>DirtyWall.exe</code>
3. You may change configuration using <code>Settings</code> in tray icon

###config.xml syntax

``` xml
<config>
  <query>car|cat</query>
  <interval>15</interval>
</config>
```

<code>&lt;query&gt;</code> - contains dash(|)-separated keywords to parse. Note, that unspecified and common keywords may produce junk<br/>
<code>&lt;interval&gt;</code> - contains non-negative integer, that represents interval of wallpaper grabbing in minutes
<br/><br/>
You may switch wallpaper any time, clicking <code>Next</code> item in tray context menu
<br/><br/>
<b>IMPORTANT</b><br/>
Previously saved images are stored in <code>cache</code> folder. After continous run cycle clean it manually, or press <code>Clean cache</code> item from tray context menu



