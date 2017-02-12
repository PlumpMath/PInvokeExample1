#!/bin/sh
pwd=`dirname $0`
/bin/sh $pwd/gen_build_ninja.sh build.ninja.erb build.ninja
