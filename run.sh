#!/usr/bin/env bash
set -o errexit

gunicorn yourprojectname.wsgi:application
