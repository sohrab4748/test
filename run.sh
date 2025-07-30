
#!/usr/bin/env bash
set -o errexit

gunicorn agrimetsoft.wsgi:application
