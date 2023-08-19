import { configureStore } from '@reduxjs/toolkit'
import filter from "./slices/filter/filterSlice.ts";
import topPosition from "./slices/topPosition/topPositionSlice.ts";
export const store = configureStore({
    reducer: {
        filter,
        topPosition,
    },
})