import { toast, updateGlobalOptions } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

updateGlobalOptions({
    autoClose: 2500,
    position: 'bottom-center',
    style: {
      opacity: '1',
      userSelect: 'initial',
    },
    theme: 'dark',
});

export function toastPrimary(msg) {
    toast(msg);
}