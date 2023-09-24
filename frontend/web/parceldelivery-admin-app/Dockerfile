# Stage 1: Compile and Build angular codebase

# Use official node image as the base image
FROM node:latest as build

# Set the working directory
WORKDIR /usr/local/app

COPY package.json package-lock.json ./
# Add the source code to app
COPY ./ /usr/local/app/

# Install all the dependencies
RUN npm install

ARG configuration=kubernetes

# Generate the build of the application
RUN npm run ng build -- --configuration=$configuration


# Stage 2: Serve app with nginx server

# Use official nginx image as the base image
FROM nginx:latest

# Copy the build output to replace the default nginx contents.
COPY --from=build /usr/local/app/dist/parceldelivery-admin-app /usr/share/nginx/html

# Expose port 80
EXPOSE 80