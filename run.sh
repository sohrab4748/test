#!/usr/bin/env bash
set -o errexit

gunicorn test.wsgi:application
