
import { up } from 'up-fetch';

export const upfetch = up(fetch, ()=>({
    timeout: 30_000,
}))