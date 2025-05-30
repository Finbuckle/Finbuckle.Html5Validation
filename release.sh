#!/bin/bash
# This script is intended for use with semantic-release prepare step with
# the exec plugin.

while getopts v:r:f: flag
do
    case "${flag}" in
        v) version=${OPTARG};;
        r) release_notes=${OPTARG};;
        f) feed_type=${OPTARG};;
    esac
done

# Update the Version property in the csproj:
sed -E -i 's|<Version>.*</Version>|<Version>'"${version}"'</Version>|g' src/Finbuckle.Html5Validation.csproj

# Update the version in readme and docs files with <span class="_version"> elements:
sed -E -i 's|<span class="_version">.*</span>|<span class="_version">'"${version}"'</span>|g' README.md

# Set text for release notes in readme (header line stripped):
release_notes_no_header=$(echo -e "${release_notes}" | tail -n +2)
perl -i -0777 -pe 's|<!--_release-notes-->.*<!--_release-notes-->|<!--_release-notes-->\n'"${release_notes_no_header}"'\n<!--_release-notes-->|s' README.md