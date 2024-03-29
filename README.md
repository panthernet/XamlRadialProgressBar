# Xaml Radial Progress Bar
[![NuGet Version and Downloads count](https://buildstats.info/nuget/XamlRadialProgressBar)](https://www.nuget.org/packages/XamlRadialProgressBar)

Display customizable radial progress bars for all your needs.

### Platfrom support:
* .NET Core 3.1+
* .NET Framework 4.6.1+ 

### Features
* Customizable templates and tons of adjustable properties
* Different modes: Fill, Shape, Pie
* Clockwise and counter-clockwise directions

![wpfxpb](https://user-images.githubusercontent.com/5926603/134169236-003f3558-4c44-467c-ae21-090322a7f692.gif)


### Simple usage

```
xmlns:xrpb="http://XamlRadialProgressBar/DotNet"

...

<Grid>
    <xrpb:RadialProgressBar Value="{Binding Value1, UpdateSourceTrigger=PropertyChanged}"
			    Width="100" Height="100"
			    Foreground="White" />
</Grid>
```

For detailed usage tips look in the Generic.xaml template and [sample application](https://github.com/panthernet/XamlRadialProgressBar/blob/master/src/XamlRadialProgressBar/Samples/Sample.Shared/DesktopControl.xaml).
