# SXA Theme Optimizations
[![Package uPersonalize](https://github.com/rbaconsulting/SXA-Theme-Optimizations/actions/workflows/release-build.yml/badge.svg)](https://github.com/rbaconsulting/SXA-Theme-Optimizations/actions/workflows/release-build.yml)
[![Build Status](https://github.com/rbaconsulting/SXA-Theme-Optimizations/actions/workflows/ci-build.yml/badge.svg)](https://github.com/rbaconsulting/SXA-Theme-Optimizations/actions/workflows/pull-request.yml)
[![Nuget Package](https://img.shields.io/badge/SXA.Theme.Optimizations-nuget.org-blue)](https://www.nuget.org/packages/SXA.Theme.Optimizations)

The SXA Themes Optimizations plugin aims to increase your SXA site(s) performance, specifically the JavaScript and CSS, and its resulting performance score within Google Lighthouse. The plugin adds functionality on top of SXA and only overwrites SXA's main layout, increasing compatibility with the SXA CLI, Creative Exchange, or however your implementation is using SXA's themes and base themes before installing the plugin.

The SXA Theme Optimizations plugin optimizes the SXA themes by:
* Bundling the various JavaScript files used by an SXA site into one file, stored in the filesystem.
* Rendering the newly optimized JavaScript file at the top of the HTML DOM.
* Rendering the newly optimized JavaScript file asynchronously.
* Preloading the CSS files so that they are no longer a render blocking resource.

#### Additional Documentation
* [Compatibility Tables](https://github.com/rbaconsulting/sxa-theme-optimizations/wiki/Compatibility-Tables)
* [Installation Guide](https://github.com/rbaconsulting/sxa-theme-optimizations/wiki/Installation-Guide)
* [Must Knows for Developers](https://github.com/rbaconsulting/sxa-theme-optimizations/wiki/Must-Knows-for-Developers)
* [Optimizing the JavaScript Files](https://github.com/rbaconsulting/sxa-theme-optimizations/wiki/Optimizing-the-JavaScript-Files)

#### Usefull Links
* [NuGet.org Package Landing Page](https://www.nuget.org/packages/SXA.Theme.Optimizations)
* [GitHub Releases and Patch Notes](https://github.com/rbaconsulting/sxa-theme-optimizations/releases)
* [Known Bugs and Issues](https://github.com/rbaconsulting/sxa-theme-optimizations/issues)
* [Active Projects and Upcoming Features](https://github.com/rbaconsulting/sxa-theme-optimizations/projects)
* [Sitecore Package Installs](https://github.com/rbaconsulting/sxa-theme-optimizations/tree/main/Sitecore%20Packages)