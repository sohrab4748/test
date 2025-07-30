
from django.shortcuts import render
import matplotlib.pyplot as plt
import io, base64

def chart_view(request):
    x = y = ''
    chart = None

    if request.method == 'POST':
        x = request.POST.get('xdata', '')
        y = request.POST.get('ydata', '')

        try:
            x_vals = [float(i.strip()) for i in x.split(',')]
            y_vals = [float(i.strip()) for i in y.split(',')]

            fig, ax = plt.subplots()
            ax.plot(x_vals, y_vals, marker='o')
            ax.set_title('Your Chart')
            ax.set_xlabel('X')
            ax.set_ylabel('Y')

            buf = io.BytesIO()
            fig.savefig(buf, format='png')
            buf.seek(0)
            chart = base64.b64encode(buf.read()).decode('utf-8')

        except Exception as e:
            chart = None

    return render(request, 'chart.html', {'chart': chart, 'x': x, 'y': y})

