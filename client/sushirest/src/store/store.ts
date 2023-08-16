import { configureStore } from '@reduxjs/toolkit'
import filter from "./slices/filter/filterSlice.ts";
export const store = configureStore({
    reducer: {
        filter,
    },
})