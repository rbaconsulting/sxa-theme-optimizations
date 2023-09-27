# SXA Theme Optimizations
[![Release Build Statis](https://github.com/rbaconsulting/SXA-Theme-Optimizations/actions/workflows/release-build.yml/badge.svg)](https://github.com/rbaconsulting/SXA-Theme-Optimizations/actions/workflows/release-build.yml)
[![CI Build Status](https://github.com/rbaconsulting/SXA-Theme-Optimizations/actions/workflows/ci-build.yml/badge.svg)](https://github.com/rbaconsulting/SXA-Theme-Optimizations/actions/workflows/pull-request.yml)
[![NuGet Package](https://img.shields.io/badge/SXA.Theme.Optimizations-nuget.org-blue)](https://www.nuget.org/packages/SXA.Theme.Optimizations)

_SXA Themes Optimizations_ helps increase Sitecore SXA site performance and its resulting Google Lighthouse (PageSpeed Insights) performance scores. This plugin adds functionality on top of SXA to further optimize front-end JavaScript/CSS files for better compatibility with the SXA CLI and Creative Exchange.

_SXA Themes Optimizations_ optimizes SXA themes by:
* Bundling all JavaScript files used by an SXA site into one file.
* Rendering the newly bundled JavaScript file at the top of the HTML DOM instead of at the bottom of the HTML DOM.
* Rendering the newly bundled JavaScript file asynchronously instead of synchronously.
* Preloading the CSS files so that they are no longer a render blocking resource.

## Additional Documentation
* [Compatibility Tables](https://github.com/rbaconsulting/sxa-theme-optimizations/wiki/Compatibility-Tables)
* [Installation Guide](https://github.com/rbaconsulting/sxa-theme-optimizations/wiki/Installation-Guide)
* [Must Knows for Developers](https://github.com/rbaconsulting/sxa-theme-optimizations/wiki/Must-Knows-for-Developers)
* [Optimizing the JavaScript Files](https://github.com/rbaconsulting/sxa-theme-optimizations/wiki/Optimizing-the-JavaScript-Files)

## Usefull Links
* [NuGet.org Package Landing Page](https://www.nuget.org/packages/SXA.Theme.Optimizations)
* [GitHub Releases and Patch Notes](https://github.com/rbaconsulting/sxa-theme-optimizations/releases)
* [Known Bugs and Issues](https://github.com/rbaconsulting/sxa-theme-optimizations/issues)
* [Active Projects and Upcoming Features](https://github.com/rbaconsulting/sxa-theme-optimizations/projects)
* [Sitecore Package Installs](https://github.com/rbaconsulting/sxa-theme-optimizations/tree/main/Sitecore%20Packages)