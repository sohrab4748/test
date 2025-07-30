
from django.shortcuts import render
import matplotlib.pyplot as plt
import io, base64

def chart_view(request):
    fig, ax = plt.subplots()
    ax.plot([1, 2, 3], [3, 2, 5])
    ax.set_title('Sample Chart')

    buf = io.BytesIO()
    fig.savefig(buf, format='png')
    buf.seek(0)
    img_base64 = base64.b64encode(buf.read()).decode('utf-8')
    return render(request, 'chart.html', {'chart': img_base64})
