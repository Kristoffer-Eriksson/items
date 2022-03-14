#!/bin/sh
MAJOR_MINOR_VERSION=`cat VERSION`
LATEST_VERSION_COMMIT=`git rev-list -1 main VERSION`
PATCH_VERSION=`git rev-list --count ${LATEST_VERSION_COMMIT}..main`
FULL_VERSION=${MAJOR_MINOR_VERSION}.${PATCH_VERSION}
OUTPUT_PATH=${PUBLISH_DIRECTORY}/${FULL_VERSION}

if [ -z "$PUBLISH_DIRECTORY" ]; then
    echo "PUBLISH_DIRECTORY needs to be set"
    exit 1
fi

if [ ! -d "$OUTPUT_PATH" ]; then
  mkdir -p $OUTPUT_PATH
fi

echo "dotnet publish -o $OUTPUT_PATH"
dotnet publish -o $OUTPUT_PATH
