# Xaml Radial Progress Bar
[![NuGet Version and Downloads count](https://buildstats.info/nuget/XamlRadialProgressBar)](https://www.nuget.org/packages/XamlRadialProgressBar)

Display customizable radial progress bars for all your needs.

### Platfrom support:
* .NET Core 3.1+
* .NET Framework 4.5.2+ 

### Features
* Customizable templates and tons of adjustable properties
* Different modes: Fill, Shape, Pie
* Clockwise and counter-clockwise directions

![bandicam 2020-03-05 15-26-32-011](https://user-images.githubusercontent.com/5926603/75991159-58066000-5ef6-11ea-981e-e8086c069e3d.gif)


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

For detailed usage tips look in the [Generic.xaml](https://github.com/panthernet/XamlRadialProgressBar/blob/master/src/XamlRadialProgressBar/Samples/Sample.Shared/DesktopControl.xaml) template and sample applicaions.
